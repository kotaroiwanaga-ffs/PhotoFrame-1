using PhotoFrame.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.EF
{
    /// <summary>
    /// <see cref="IPhotoRepository">の実装クラス
    /// </summary>
    class PhotoRepository : IPhotoRepository
    {
        private List<Photo> dbPhotos;

        public PhotoRepository()
        {
            this.dbPhotos = new List<Photo>();
            // SearchFolderTest
            //dbPhotos.Add(new Photo(new File(@"Album3\Lighthouse.jpg"), new DateTime()));
            //dbPhotos.Add(new Photo(new File(@"Album3\Penguins.jpg"), new DateTime()));
            //dbPhotos.Add(new Photo(new File(@"Album3\Tulips.jpg"), new DateTime()));

            // AddKeywordTest1,2,3
            //dbPhotos.Add(new Photo(new File(@"Album1\Chrysanthemum.jpg"), new DateTime(), new string[] { "a" }));
            //dbPhotos.Add(new Photo(new File(@"Album1\Desert.jpg"), new DateTime(), new string[] { "a", "b" }));

            // AddKeywordTest4,5,6
            dbPhotos.Add(new Photo(new File(@"Album1\Chrysanthemum.jpg"), new DateTime(), new string[] { "a" }));
            dbPhotos.Add(new Photo(new File(@"Album1\Desert.jpg"), new DateTime(), new string[] { "a", "b", "c", "d", "e" }));

        }

        public bool Exists(Photo entity)
        {
            List<Photo> list = (from p in this.dbPhotos where entity.File.FilePath == p.File.FilePath select p).ToList();

            if (list.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool ExistsBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public IEnumerable<Photo> Find(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            return query(this.dbPhotos.AsQueryable()).AsEnumerable();
        }

        public Photo Find(Func<IQueryable<Photo>, Photo> query)
        {
            return query(this.dbPhotos.AsQueryable());
        }

        public Photo FindBy(string id)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }

        public Photo Store(Photo entity)
        {
            return entity;
        }

        public void StoreIfNotExists(IEnumerable<Photo> photos)
        {
            // TODO: DBプログラミング講座で実装
            throw new NotImplementedException();
        }
    }
}
