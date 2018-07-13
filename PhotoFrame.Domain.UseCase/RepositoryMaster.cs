using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence;

namespace PhotoFrame.Domain.UseCase
{
    public class RepositoryMaster
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IPhotoRepository photoRepository;
        //private readonly SlideShowRepository slideShowRepository;

        private IEnumerable<Photo> allPhotos;

        public RepositoryMaster()
        {
            RepositoryFactory repositoryFactory = new RepositoryFactory(PhotoFrame.Persistence.Type.Csv);
            photoRepository = repositoryFactory.PhotoRepository;
            albumRepository = repositoryFactory.AlbumRepository;
            //slideShowRepository = new SlideShowRepository();

            allPhotos = new List<Photo>();
        }
        
        public void SetAllPhotos(IEnumerable<Photo> photos)
        {
            this.allPhotos = photos;
        }

        public IEnumerable<Photo> Filter(Func<Photo, bool> query)
        {
            List<Photo> filterdPhotos = new List<Photo>();

            foreach(Photo photo in allPhotos)
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
            return photoRepository.Find(query);
        }

        public Photo FindPhoto(Func<IQueryable<Photo>, Photo> query)
        {
            return photoRepository.Find(query);
        }

        public Photo StorePhoto(Photo photo)
        {
            return photoRepository.Store(photo);
        }

        public bool ExistsPhoto(Photo photo)
        {
            return photoRepository.Exists(photo);
        }

        public IEnumerable<Album> FindAlbum(Func<IQueryable<Album>, IQueryable<Album>> query)
        {
            return albumRepository.Find(query);
        }

        public Album FindAlbum(Func<IQueryable<Album>, Album> query)
        {
            return albumRepository.Find(query);
        }

        public Album StoreAlbum(Album album)
        {
            return albumRepository.Store(album);
        }

        public bool ExistsAlbum(Album album)
        {
            return albumRepository.Exists(album);
        }

        public IEnumerable<string> FindSlideShow(Album album)
        {
            //return slideShowRepository.Find(album);
            return null;
        }

        public Album StoreSlideShow(Album album, IEnumerable<Photo> photos)
        {
            //return slideShowRepository.Store(album, photos);
            return null;
        }
    

        // Dummy Method /////////////////////////////////////////////////////



    }
}
