using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class ToggleIsFavorite
    {
        private readonly RepositoryMaster repositoryMaster;


        public ToggleIsFavorite(RepositoryMaster repositoryMaster)
        {
            this.repositoryMaster = repositoryMaster;
        }

        /// <summary>
        /// photosの各要素のお気に入りを登録/解除する
        /// 
        /// photosの中に一つでもIsFavorite = falseがあればすべてのisFavoriteをtrueに
        /// すべてfalseならすべてtrueに
        /// </summary>
        /// <param name="photos"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(IEnumerable<Photo> photos)
        {
            // photosをIsFavorite = falseのものだけに絞り込み
            var unFavoritePhotos = photos.Where(p => p.IsFavorite == false).ToList();

            // IsFavorite = falseが一つ以上あった場合
            if (unFavoritePhotos.Count() > 0)
            {
                foreach(Photo photo in unFavoritePhotos)
                {
                    photo.MarkAsFavorite();
                    repositoryMaster.StorePhoto(photo);
                }
            }
            // すべてIsFavorite = trueだった場合
            else
            {
                foreach(Photo photo in photos)
                {
                    photo.MarkAsUnFavorite();
                    repositoryMaster.StorePhoto(photo);
                }
            }
           
            return photos;
        } 
    }
}
