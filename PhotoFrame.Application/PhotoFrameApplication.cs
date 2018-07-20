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
    public class PhotoFrameApplication
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


        public PhotoFrameApplication()
        {
            this.ServiceFactory = new ServiceFactory();

            //this.repositoryMaster = new RepositoryMaster();
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

        public IEnumerable<Photo> SearchFolder(string folderPath)
        {
            return this.searchFolder.Execute(folderPath);
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

        public IEnumerable<Album> GetAllAlbums()
        {
            return this.getAllAlbums.Execute();
        }

        
    }
}
