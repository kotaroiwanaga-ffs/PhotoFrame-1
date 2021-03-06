﻿using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Persistence;

namespace PhotoFrame.Application
{
    /// <summary>
    /// PhotoFrameのUIの指示にしたがってドメインのユースケースを起動する
    /// </summary>
    // TODO: 仮実装
    public class PhotoFrameApplicationTest
    {
        private RepositoryMaster repositoryMaster;
        private ServiceFactory ServiceFactory;
        private IPhotoFileService photoFileService;

        private readonly SearchFolder searchFolder;
        private readonly Filter filter;
        private readonly AddKeyword addKeyword;
        private readonly DeleteKeyword deleteKeyword;
        private readonly ToggleIsFavorite toggleIsFavorite;
        private readonly AddAlbum addAlbum;
        private readonly SearchAlbum searchAlbum;
        private readonly SortDateAscending sortDateAscending;
        private readonly SortDateDescending sortDateDescending;
        private readonly GetAllAlbums getAllAlbums;


        public PhotoFrameApplicationTest()
        {
            this.ServiceFactory = new ServiceFactory();

            this.repositoryMaster = new RepositoryMaster();
            this.photoFileService = ServiceFactory.PhotoFileService;

            this.searchFolder = new SearchFolder(repositoryMaster, photoFileService);
            this.filter = new Filter(repositoryMaster);
            this.addKeyword = new AddKeyword(repositoryMaster);
            this.deleteKeyword = new DeleteKeyword(repositoryMaster);
            this.toggleIsFavorite = new ToggleIsFavorite(repositoryMaster);
            this.addAlbum = new AddAlbum(repositoryMaster);
            this.searchAlbum = new SearchAlbum(repositoryMaster);
            this.sortDateAscending = new SortDateAscending();
            this.sortDateDescending = new SortDateDescending();
            this.getAllAlbums = new GetAllAlbums(repositoryMaster);

        }

        public IEnumerable<Photo> SearchFolder(string filePath)
        {
            Photo a;
            Photo b;
            Photo c;
            List<string> aaaa = new List<string>();
            string[] aaa = { "a", "b", "aaaa" };
            string[] bbb = { "test", "takemoto" };
            DateTime date_E = DateTime.Now;

            a = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(), aaa, true);
            b = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Desert.jpg"), date_E, aaaa, false);
            c = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Hydrangeas.jpg"), date_E, bbb.ToList(), false);
            Photo[] photos = { a, b, c };
            return photos.AsEnumerable<Photo>();
        }

        public IEnumerable<Photo> Filter(string keyword, bool isFavorite, DateTime firstDate, DateTime lastDate)
        {
            Photo a;
            Photo b;
            Photo c;
            List<string> aaaa = new List<string>();
            string[] aaa = { "a", "b", "aaaa" };
            string[] bbb = { "test", "takemoto" };
            DateTime date_E = DateTime.Now;

            a = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(), aaa, true);
            b = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Desert.jpg"), date_E, aaaa, false);
            c = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Hydrangeas.jpg"), date_E, bbb.ToList(), false);
            Photo[] photos = { a, b};
            return photos.AsEnumerable<Photo>();
        }

        public bool AddKeyword(string keyword, IEnumerable<Photo> photos)
        {
            Photo a;
            Photo b;
            Photo c;
            List<string> aaaa = new List<string>();
            string[] aaa = { "a", "b", "aaaa" };
            string[] bbb = { "test", "takemoto","new!" };
            DateTime date_E = DateTime.Now;

            a = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(), aaa, true);
            b = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Desert.jpg"), date_E, aaaa, false);
            c = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Hydrangeas.jpg"), date_E, bbb.ToList(), false);
            Photo[] photosa = { a, b, c };
            return true;
        }

        public bool DeleteKeyword(string keyword, IEnumerable<Photo> photos)
        {
            Photo a;
            Photo b;
            Photo c;
            List<string> aaaa = new List<string>();
            string[] aaa = { "a", "b", "aaaa" };
            string[] bbb = { "test", };
            DateTime date_E = DateTime.Now;

            a = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(), aaa, true);
            b = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Desert.jpg"), date_E, aaaa, false);
            c = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Hydrangeas.jpg"), date_E, bbb.ToList(), false);
            Photo[] photosa = { a, b, c };
            return true;
        }

        public IEnumerable<Photo> ToggleIsFavorite(IEnumerable<Photo> photos)
        {
            Photo a;
            Photo b;
            Photo c;
            List<string> aaaa = new List<string>();
            string[] aaa = { "a", "b", "aaaa" };
            string[] bbb = { "test", };
            DateTime date_E = DateTime.Now;

            a = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(), aaa, true);
            b = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Desert.jpg"), date_E, aaaa, false);
            c = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Hydrangeas.jpg"), date_E, bbb.ToList(), true);
            Photo[] photosa = { a, b, c };
            return photos.AsEnumerable<Photo>();
        }

        public bool AddAlbum(string albumName, IEnumerable<Photo> photos)
        {
            return this.addAlbum.Execute(albumName, photos);
        }

        public IEnumerable<Photo> SearchAlbum(string albumName)
        {
            return this.searchAlbum.Execute(albumName);
        }

        public IEnumerable<Photo> SortDateAscending(IEnumerable<Photo> photos)
        {
            Photo a;
            Photo b;
            Photo c;
            List<string> aaaa = new List<string>();
            string[] aaa = { "a", "b", "aaaa" };
            string[] bbb = { "test", "takemoto" };
            DateTime date_E = DateTime.Now;

            a = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(), aaa, true);
            b = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Desert.jpg"), date_E, aaaa, false);
            c = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Hydrangeas.jpg"), date_E, bbb.ToList(), false);
            Photo[] photosa = {b, c ,a };
            return photosa.AsEnumerable<Photo>();
        }

        public IEnumerable<Photo> SortDateDescending(IEnumerable<Photo> photos)
        {
            Photo a;
            Photo b;
            Photo c;
            List<string> aaaa = new List<string>();
            string[] aaa = { "a", "b", "aaaa" };
            string[] bbb = { "test", "takemoto" };
            DateTime date_E = DateTime.Now;

            a = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(), aaa, true);
            b = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Desert.jpg"), date_E, aaaa, false);
            c = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Hydrangeas.jpg"), date_E, bbb.ToList(), false);
            Photo[] photosa = { a,b,c };
            return photosa.AsEnumerable<Photo>();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            return this.getAllAlbums.Execute();
        }

        //public int CreateAlbum(string albumName)
        //{
        //    return createAlbum.Execute(albumName);
        //}

        //public async Task<int> CreateAlbumAsync(string albumName)
        //{
        //    return await createAlbum.ExecuteAsync(albumName);
        //}



        //public IEnumerable<Photo> SearchAlbum(string albumName)
        //{
        //    return searchAlbum.Execute(albumName);
        //}

        //public async Task<IEnumerable<Photo>> SearchAlbumAsync(string albumName)
        //{
        //    return await searchAlbum.ExecuteAsync(albumName);
        //}



        //public IEnumerable<Photo> SearchDirectory(string directoryName)
        //{
        //    return searchDirectory.Execute(directoryName);
        //}

        //public async Task<IEnumerable<Photo>> SearchDirectoryAsync(string directoryName)
        //{
        //    return await searchDirectory.ExecuteAsync(directoryName);
        //}



        //public Photo ToggleFavorite(Photo photo)
        //{
        //    return toggleFavorite.Execute(photo);
        //}

        //public async Task<Photo> ToggleFavoriteAsync(Photo photo)
        //{
        //    return await toggleFavorite.ExecuteAsync(photo);
        //}



        //public Photo ChangeAlbum(Photo photo, string newAlbumName)
        //{
        //    return changeAlbum.Execute(photo, newAlbumName);
        //}

        //public async Task<Photo> ChangeAlbumAsync(Photo photo, string newAlbumName)
        //{
        //    return await changeAlbum.ExecuteAsync(photo, newAlbumName);
        //}
    }
}
