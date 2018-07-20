using PhotoFrame.Domain.Model;
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
            b = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Desert.jpg"), new DateTime(1993, 7, 17), aaaa, false);
            c = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album1\Hydrangeas.jpg"), date_E, bbb.ToList(), false);
            //Photo[] photos = { a, b, c };
            //for(int i = 0;i<7;i++)
            //{
            //    photos = photos.Concat(photos).ToArray();
            //}
            Photo[] photos = {a,b,c };
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
            Photo[] photosaa = {};
            return photosaa.AsEnumerable<Photo>();
        }

        public bool AddKeyword(string keyword, IEnumerable<Photo> photos)
        {
            bool success = false;

            foreach (Photo photo in photos)
            {
                if (photo.AddKeyword(keyword))
                {
                    //repositoryMaster.StorePhoto(photo);
                    success = true;
                }
            }

            return success;
        }

        public bool DeleteKeyword(string keyword, IEnumerable<Photo> photos)
        {
            bool success = false;

            foreach (Photo photo in photos)
            {
                if (photo.DeleteKeyword(keyword))
                {
                    //repositoryMaster.StorePhoto(photo);
                    success = true;
                }
            }

            return success;
        }

        public IEnumerable<Photo> ToggleIsFavorite(IEnumerable<Photo> photos)
        {
            var unFavoritePhotos = photos.Where(p => p.IsFavorite == false).ToList();

            if (unFavoritePhotos.Count() > 0)
            {
                foreach (Photo photo in unFavoritePhotos)
                {
                    photo.MarkAsFavorite();
                }
            }
            else
            {
                foreach (Photo photo in photos)
                {
                    photo.MarkAsUnFavorite();
                }
            }
            return photos.AsEnumerable<Photo>();
        }

        public bool AddAlbum(string albumName, IEnumerable<Photo> photos)
        {
            return true;
            //return false;
        }

        public IEnumerable<Photo> SearchAlbum(string albumName)
        {
            Photo a;
            Photo b;
            Photo c;
            List<string> aaaa = new List<string>();
            string[] aaa = { "a", "b", "aaaa" };
            string[] bbb = { "test", "takemoto" };
            DateTime date_E = DateTime.Now;

            a = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album2\Jellyfish.jpg"), new DateTime(), aaa, true);
            b = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album2\Koala.jpg"), date_E, aaaa, false);
            c = new Photo(new PhotoFrame.Domain.Model.File(@"C:\研修用\Album2\Lighthouse.jpg"), date_E, bbb.ToList(), false);
            Photo[] photosa = { a, b, c };
            return photosa.AsEnumerable<Photo>();

        }

        public IEnumerable<Photo> SortDateAscending(IEnumerable<Photo> photos)
        {
            DateTime defaultDate = new DateTime();

            var tempPhotos = photos.Where(p => p.Date != defaultDate).OrderBy(p => p.Date).ToList();
            var defaultPhotos = photos.Where(p => p.Date == defaultDate);

            foreach (Photo photo in defaultPhotos)
            {
                tempPhotos.Add(photo);
            }

            return tempPhotos;
        }

        public IEnumerable<Photo> SortDateDescending(IEnumerable<Photo> photos)
        {
            return photos.OrderByDescending(p => p.Date);
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            List<Album> list = new List<Album>();

            Album album1 = new Album("abc", "test1", "test説明");
            Album album2 = new Album("def", "test2", "test1説明");
            Album album3 = new Album("ghi", "test3", "test2説明");

            list.Add(album1);
            list.Add(album2);
            list.Add(album3);

            return list;
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
