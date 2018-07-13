using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    class PhotoRepository : IPhotoRepository
    {
        public IEnumerable<Photo> Find()
        {
            using (TeamBEntities database = new TeamBEntities())
            {
                List<Photo> photolist = new List<Photo>();

                foreach (var photodata in database.PHOTO_TABLE)
                {
                    File file = new File(photodata.FILEPATH);
                    bool isfavorite = Convert.ToBoolean(photodata.ISFAVORITE);
                    DateTime date = DateTime.Parse(photodata.TAKEDATE);

                    List<string> keywords = new List<string>();
                    foreach(var keyword in database.KEYWORD_TABLE)
                    {
                        if(keyword.FILEPATH == photodata.FILEPATH)
                        {
                            keywords.Add(keyword.KEYWORD);
                        }
                    }

                    Photo photo = new Photo(file, date, keywords, isfavorite);
                    photolist.Add(photo);
                }

                return photolist.AsQueryable();
            }
        }

        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            return query(Find().AsQueryable());
        }

        public Photo Find(Func<IQueryable<Photo>, Photo> query)
        {
            return query(Find().AsQueryable());
        }

        public Photo Store(Photo photo)
        {
            using (TeamBEntities database = new TeamBEntities())
            using(var transaction = database.Database.BeginTransaction())
            {
                try
                {
                    if (Exists(photo))
                    {
                        SaveFavorite(photo);
                        SaveKeywords(photo);
                    }
                    else
                    {
                        var photodata = new PHOTO_TABLE
                        {
                            FILEPATH = photo.File.FilePath,
                            ISFAVORITE = photo.IsFavorite,
                            TAKEDATE = photo.Date.ToString()
                        };
                        database.PHOTO_TABLE.Add(photodata);

                        foreach (var keyword in photo.Keywords)
                        {
                            var keyworddata = new KEYWORD_TABLE
                            {
                                FILEPATH = photo.File.FilePath,
                                KEYWORD = keyword
                            };
                            database.KEYWORD_TABLE.Add(keyworddata);
                        }
                    }
                    transaction.Commit();
                    database.SaveChanges();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
            return photo;
        }

        private void SaveFavorite(Photo photo)
        {
            using (TeamBEntities database = new TeamBEntities())
            using (var transaction = database.Database.BeginTransaction())
            {
                try
                {
                    var photodata = database.PHOTO_TABLE.Find(photo.File.FilePath);
                    photodata.ISFAVORITE = photo.IsFavorite;

                    transaction.Commit();
                    database.SaveChanges();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        private void SaveKeywords(Photo photo)
        {
            using (TeamBEntities database = new TeamBEntities())
            using (var transaction = database.Database.BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                    database.SaveChanges();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }

        public bool Exists(Photo photo)
        {
            foreach (var pho in Find())
            {
                if (pho.File.FilePath == photo.File.FilePath) return true;
            }

            return false;
        }

        public bool ExistsBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public Photo FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }
    }
}
