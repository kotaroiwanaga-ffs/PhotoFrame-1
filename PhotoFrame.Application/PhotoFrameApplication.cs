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
        private readonly CreateAlbum createAlbum;
        private readonly SearchAlbum searchAlbum;
        private readonly SearchDirectory searchDirectory;
        private readonly ToggleFavorite toggleFavorite;
        private readonly ChangeAlbum changeAlbum;

        public PhotoFrameApplication(IAlbumRepository albumRepository, IPhotoRepository photoRepository, IPhotoFileService photoFileService)
        {
            this.createAlbum = new CreateAlbum(albumRepository);
            this.searchAlbum = new SearchAlbum(photoRepository);
            this.searchDirectory = new SearchDirectory(photoRepository, photoFileService);
            this.toggleFavorite = new ToggleFavorite(photoRepository);
            this.changeAlbum = new ChangeAlbum(albumRepository, photoRepository);
        }

        public int CreateAlbum(string albumName)
        {
            return createAlbum.Execute(albumName);
        }

        public async Task<int> CreateAlbumAsync(string albumName)
        {
            return await createAlbum.ExecuteAsync(albumName);
        }



        public IEnumerable<Photo> SearchAlbum(string albumName)
        {
            return searchAlbum.Execute(albumName);
        }

        public async Task<IEnumerable<Photo>> SearchAlbumAsync(string albumName)
        {
            return await searchAlbum.ExecuteAsync(albumName);
        }



        public IEnumerable<Photo> SearchDirectory(string directoryName)
        {
            return searchDirectory.Execute(directoryName);
        }

        public async Task<IEnumerable<Photo>> SearchDirectoryAsync(string directoryName)
        {
            return await searchDirectory.ExecuteAsync(directoryName);
        }



        public Photo ToggleFavorite(Photo photo)
        {
            return toggleFavorite.Execute(photo);
        }

        public async Task<Photo> ToggleFavoriteAsync(Photo photo)
        {
            return await toggleFavorite.ExecuteAsync(photo);
        }



        public Photo ChangeAlbum(Photo photo, string newAlbumName)
        {
            return changeAlbum.Execute(photo, newAlbumName);
        }

        public async Task<Photo> ChangeAlbumAsync(Photo photo, string newAlbumName)
        {
            return await changeAlbum.ExecuteAsync(photo, newAlbumName);
        }
    }
}
