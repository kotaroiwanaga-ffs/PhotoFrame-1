using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class ChangeAlbum
    {
        private readonly IAlbumRepository albumRepository;
        private readonly IPhotoRepository photoRepository;

        public ChangeAlbum(IAlbumRepository albumRepository, IPhotoRepository photoRepository)
        {
            this.albumRepository = albumRepository;
            this.photoRepository = photoRepository;
        }

        /// <summary>
        /// 引数のフォトの所属アルバムを変更する
        /// ※参照渡しなので返り値を保存しなくても書き換わる
        /// </summary>
        /// <param name="photo"></param>
        /// <param name="newAlbumName"></param>
        /// <returns></returns>
        public Photo Execute(Photo photo, string newAlbumName)
        {
            Func<IQueryable<Album>, Album> query = allAlbums =>
            {
                foreach (Album album in allAlbums)
                {
                    if (album.Name == newAlbumName)
                    {
                        return album;
                    }
                }

                return null;
            };

            Album newAlbum = albumRepository.Find(query);

            if(newAlbum != null)
            {
                photo.IsAssignedTo(newAlbum);
            }

            photoRepository.Store(photo);

            return photo;
        }
    }
}
