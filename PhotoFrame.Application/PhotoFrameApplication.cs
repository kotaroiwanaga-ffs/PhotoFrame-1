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

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PhotoFrameApplication()
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

        /// <summary>
        /// 指定したフォルダパス配下の画像ファイルをPhoto型に変換してリストで返す
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public IEnumerable<Photo> SearchFolder(string folderPath)
        {
            return this.searchFolder.Execute(folderPath);
        }

        /// <summary>
        /// RepositoryMasterの保持するフォトリストのうち条件に合うものだけを返す(絞り込み)
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="isFavorite"></param>
        /// <param name="firstDate"></param>
        /// <param name="lastDate"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Filter(string keyword , bool isFavorite, DateTime firstDate, DateTime lastDate)
        {
            return this.filter.Execute(keyword, isFavorite, firstDate, lastDate);
        }

        /// <summary>
        /// photosの各要素に指定したキーワードを追加する
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="photos"></param>
        /// <returns></returns>
        public bool AddKeyword(string keyword, IEnumerable<Photo> photos)
        {
            return this.addKeyword.Execute(keyword, photos);
        }

        /// <summary>
        /// photosの各要素から指定したキーワードを削除する
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="photos"></param>
        /// <returns></returns>
        public bool DeleteKeyword(string keyword, IEnumerable<Photo> photos)
        {
            return this.deleteKeyword.Execute(keyword, photos);
        }

        /// <summary>
        /// photosの各要素のお気に入りを登録/解除する
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        public IEnumerable<Photo> ToggleIsFavorite(IEnumerable<Photo> photos)
        {
            return this.toggleIsFavorite.Execute(photos);
        }

        /// <summary>
        /// photosを指定したアルバム名のアルバムとして保存する
        /// </summary>
        /// <param name="albumName"></param>
        /// <param name="photos"></param>
        /// <returns></returns>
        public bool AddAlbum(string albumName, IEnumerable<Photo> photos)
        {
            return this.addAlbum.Execute(albumName, photos);
        }

        /// <summary>
        /// 指定したアルバム名のアルバムに所属するフォトのリストを返す
        /// </summary>
        /// <param name="albumName"></param>
        /// <returns></returns>
        public IEnumerable<Photo> SearchAlbum(string albumName)
        {
            return this.searchAlbum.Execute(albumName);
        }

        /// <summary>
        /// photosを撮影日時昇順に並び替えて返す
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        public IEnumerable<Photo> SortDateAscending(IEnumerable<Photo> photos)
        {
            return this.sortDateAscending.Execute(photos);
        }

        /// <summary>
        /// photosを撮影日時降順に並び替えて返す
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        public IEnumerable<Photo> SortDateDescending(IEnumerable<Photo> photos)
        {
            return this.sortDateDescending.Execute(photos);
        }

        /// <summary>
        /// 保存済みのすべてのアルバムを返す
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Album> GetAllAlbums()
        {
            return this.getAllAlbums.Execute();
        }

        
    }
}
