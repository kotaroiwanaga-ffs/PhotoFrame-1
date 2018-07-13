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
