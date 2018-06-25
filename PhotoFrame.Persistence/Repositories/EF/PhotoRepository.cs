using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SqlClient;
using PhotoFrame.Persistence.Repositories.EF;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    class PhotoRepository : IPhotoRepository
    {
        public bool Exists(Photo entity)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public bool ExistsBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            // TODO: DBプログラミング講座で実装
            return query(FindAll());
        }

        public Photo Find(Func<IQueryable<Photo>, Photo> query)
        {
            // TODO: DBプログラミング講座で実装
            return query(FindAll());
        }

        public Photo FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            return Find((IQueryable<Photo> allPhotos) => { return (from photo in allPhotos where photo.Id == id select photo).FirstOrDefault(); });
        }

        public Photo Store(Photo entity)
        {
            using(PhotoFrameDBEntities dbentity = new PhotoFrameDBEntities())
            {
                using(var transaction = dbentity.Database.BeginTransaction())
                {
                    Guid guid = Guid.Parse(entity.Id);
                    Table_Photo hit_table_Photo = (from t_photo in dbentity.Table_Photo where t_photo.Id == guid select t_photo).FirstOrDefault();

                    try
                    {
                        // Update
                        if (hit_table_Photo != null)
                        {
                            hit_table_Photo.FilePath = entity.File.FilePath;
                            hit_table_Photo.isFavorite = entity.IsFavorite;
                            if(entity.AlbumId != null)
                            {
                                hit_table_Photo.AlbumId = Guid.Parse(entity.AlbumId);
                            }
                            
                        }
                        // Insert
                        else
                        {
                            Table_Photo newTable_Photo = ToDatabase(entity);
                            dbentity.Table_Photo.Add(newTable_Photo);
                        }

                        transaction.Commit();
                        dbentity.SaveChanges();

                        return entity;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
                
            }
        }

        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        private IQueryable<Photo> FindAll()
        {
            using(PhotoFrameDBEntities dbentity = new PhotoFrameDBEntities())
            {
                return ToPhoto(dbentity.Table_Photo.Include(s => s.Table_Album));
            }
        }

        private Photo ToPhoto(Table_Photo table_Photo)
        {
            if(table_Photo != null)
            {
                Domain.Model.File file = new File(table_Photo.FilePath);
                string albumId = table_Photo.AlbumId?.ToString();
                Album album = null;

                if (albumId != null)
                {
                    album = new Album(table_Photo.Table_Album.Id.ToString(), table_Photo.Table_Album.Name, table_Photo.Table_Album.Descript);
                }

                return new Photo(table_Photo.Id.ToString(), file, table_Photo.isFavorite, albumId, album);
            }
            else
            {
                return null;
            }
            
        }

        private IQueryable<Photo> ToPhoto(IQueryable<Table_Photo> table_Photos)
        {
            List<Photo> photos = new List<Photo>();

            foreach(Table_Photo table_Photo in table_Photos)
            {
                photos.Add(ToPhoto(table_Photo));
            }

            return photos.AsQueryable();
        }

        private Table_Photo ToDatabase(Photo photo)
        {
            if(photo != null)
            {
                Table_Photo table_Photo = new Table_Photo();

                table_Photo.Id = Guid.Parse(photo.Id);
                table_Photo.FilePath = photo.File.FilePath;
                table_Photo.isFavorite = photo.IsFavorite;
                
                if(photo.AlbumId != null)
                {
                    table_Photo.AlbumId = Guid.Parse(photo.AlbumId);
                }

                return table_Photo;
            }
            else
            {
                return null;
            }
        }

        private IQueryable<Table_Photo> ToDatabase(IQueryable<Photo> photos)
        {
            List<Table_Photo> table_Photos = new List<Table_Photo>();

            foreach(Photo photo in photos)
            {
                table_Photos.Add(ToDatabase(photo));
            }

            return table_Photos.AsQueryable();
        }
    }
}
