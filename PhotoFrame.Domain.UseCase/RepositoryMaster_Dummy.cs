using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;

namespace PhotoFrame.Domain.UseCase
{
    public class RepositoryMaster_Dummy : RepositoryMaster
    {
        private IEnumerable<Photo> allPhotos;
        private List<Photo> dbPhotos;
        private List<Album> dbAlbums;
        private List<string[]> dbSlide;

        public RepositoryMaster_Dummy()
        {
            this.allPhotos = new List<Photo>();
            this.dbPhotos = new List<Photo>();
            this.dbAlbums = new List<Album>();

            this.dbSlide = new List<string[]>();
            dbSlide.Add(new string[] { "test1", @"C:\研修用\Album1\Chrysanthemum.jpg" });


            string[] array1 = new string []{"a", "b", "c" };
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(), array1.ToList<string>(),true ));
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Desert.jpg"), new DateTime(), array1.ToList<string>(), true));
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Hydrangeas.jpg"), new DateTime(), array1.ToList<string>(), false));

            dbAlbums.Add(new Album("abc", "test1", "test0説明"));
            dbAlbums.Add(new Album("def", "test2", "test1説明"));
            dbAlbums.Add(new Album("ghi", "test3", "test2説明"));


        }

        public void SetAllPhotos(IEnumerable<Photo> photos)
        {
            this.allPhotos = photos;
        }

        public IEnumerable<Photo> Filter(Func<Photo, bool> query)
        {
            List<Photo> filterdPhotos = new List<Photo>();

            foreach (Photo photo in allPhotos)
            {
                if (query(photo))
                {
                    filterdPhotos.Add(photo);
                }
            }

            return filterdPhotos;
        }

        public IEnumerable<Photo> Filter(Func<Photo, bool> query, IEnumerable<Photo> photos)
        {
            List<Photo> filterdPhotos = new List<Photo>();

            foreach (Photo photo in photos)
            {
                if (query(photo))
                {
                    filterdPhotos.Add(photo);
                }
            }

            return filterdPhotos;
        }

        public IEnumerable<Photo> FindPhoto(Func<IQueryable<Photo>, IQueryable<Photo>> query)
        {
            //return photoRepository.Find(query);
            return query(this.dbPhotos.AsQueryable()).AsEnumerable();
        }

        public Photo FindPhoto(Func<IQueryable<Photo>, Photo> query)
        {
            //return photoRepository.Find(query);
            return query(this.dbPhotos.AsQueryable());
        }

        public Photo StorePhoto(Photo photo)
        {
            return photo;
        }

        public bool ExistsPhoto(Photo photo)
        {
            List<Photo> list = (from p in this.dbPhotos where photo.File.FilePath == p.File.FilePath select p).ToList();

            if (list.Count() == 0)
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        public IEnumerable<Album> FindAlbum(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            return query(this.dbAlbums.AsQueryable()).AsEnumerable();
        }

        public Album FindAlbum(Func<IQueryable<Album>, Album> query)
        {
            return query(this.dbAlbums.AsQueryable());
        }

        public Album StoreAlbum(Album album)
        {
            return album;
        }

        public bool ExistsAlbum(Album album)
        {
            List<Album> list = (from a in this.dbAlbums where album.Name == a.Name select a).ToList();

            if (list.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public IEnumerable<string> FindSlideShow(Album album)
        {
            List<string> list = new List<string>();
            foreach ( var p in this.dbSlide)
            {
                if(p[0] == album.Name)
                {
                    list.Add(p[1]);
                }
            }

            return list;
        }

        public Album StoreSlideShow(Album album, IEnumerable<Photo> photos)
        {
            return album;
        }
    }
}
