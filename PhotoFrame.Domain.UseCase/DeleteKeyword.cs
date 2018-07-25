using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class DeleteKeyword
    {
        private RepositoryMaster repositoryMaster;

        public DeleteKeyword(RepositoryMaster repositoryMaster)
        {
            this.repositoryMaster = repositoryMaster;
        }

        /// <summary>
        /// photosの各要素から指定したキーワードを削除する
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="photos"></param>
        /// <returns>photosのうち一つでもキーワード削除が成功したらtrue</returns>
        public bool Execute(string keyword, IEnumerable<Photo> photos)
        {
            bool success = false;

            foreach(Photo photo in photos)
            {
                if (photo.DeleteKeyword(keyword))
                {
                    repositoryMaster.StorePhoto(photo);
                    success = true;
                }
            }

            return success;
        }
    }
}
