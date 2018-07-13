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

        public IEnumerable<Photo> Execute(IEnumerable<Photo> photos)
        {
            var unFavoritePhotos = photos.Where(p => p.IsFavorite == false).ToList();

            if (unFavoritePhotos.Count() > 0)
            {
                foreach(Photo photo in unFavoritePhotos)
                {
                    photo.MarkAsFavorite();
                    repositoryMaster.StorePhoto(photo);
                }
            }
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
