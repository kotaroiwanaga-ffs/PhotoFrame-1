using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class AddAlbum
    {
        private readonly RepositoryMaster repositoryMaster;

        public AddAlbum(RepositoryMaster repositoryMaster)
        {
            this.repositoryMaster = repositoryMaster;
        }

        public bool Execute(string albumName, IEnumerable<Photo> photos)
        {


            return true;
        }
    }
}
