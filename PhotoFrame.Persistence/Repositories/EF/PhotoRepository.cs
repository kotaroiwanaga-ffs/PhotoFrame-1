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
            string[] array1 = new string[] { "a", "b", "c" };
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(), array1.ToList<string>(), true));
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Desert.jpg"), new DateTime(), array1.ToList<string>(), true));
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Hydrangeas.jpg"), new DateTime(), array1.ToList<string>(), false));



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
