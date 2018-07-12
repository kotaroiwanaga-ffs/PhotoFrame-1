using PhotoFrame.Domain.Model;
using PhotoFrame.Domain.UseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Application
{
    /// <summary>
    /// PhotoFrameのUIの指示にしたがってドメインのユースケースを起動する
    /// </summary>
    // TODO: 仮実装
    public class PhotoFrameApplication
    {
        private RepositoryMaster repositoryMaster;

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


        public PhotoFrameApplication(IAlbumRepository albumRepository, IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            this.repositoryMaster = new RepositoryMaster();

            this.searchFolder = new SearchFolder(repositoryMaster);
            this.filter = new Filter();
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
            return this.searchFolder.Execute(filePath);
        }

        public IEnumerable<Photo> Filter(string keyword , bool isFavorite, DateTime firstDate, DateTime lastDate)
        {
            return this.filter.Execute(keyword, isFavorite, firstDate, lastDate);
        }

        public bool AddKeyword(string keyword, IEnumerable<Photo> photos)
        {
            return this.addKeyword.Execute(keyword, photos);
        }

        public bool DeleteKeyword(string keyword, IEnumerable<Photo> photos)
        {
            return this.deleteKeyword.Execute(keyword, photos);
        }

        public IEnumerable<Photo> ToggleIsFavorite(IEnumerable<Photo> photos)
        {
            return this.toggleIsFavorite.Execute(photos);
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
            return this.sortDateAscending.Execute(photos);
        }

        public IEnumerable<Photo> SortDateDescending(IEnumerable<Photo> photos)
        {
            return this.sortDateDescending.Execute(photos);
        }

        public IEnumerable<Album> GetAlbums()
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
