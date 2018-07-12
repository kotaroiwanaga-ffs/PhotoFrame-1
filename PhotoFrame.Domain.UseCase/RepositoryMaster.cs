﻿using System;
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
            List<Photo> photos = new List<Photo>();

            foreach(Photo photo in allPhotos)
            {
                if (query(photo))
                {
                    photos.Add(photo);
                }
            }

            return photos;
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

        //public IEnumerable<string> FindSlideShow(Album album)
        //{
        //    return slideShowRepository.Find(album);
        //}

        //public Album StoreSlideShow(Album album, IEnumerable<Photo> photos)
        //{
        //    return slideShowRepository.Store(album, photos);
        //}

    }
}
