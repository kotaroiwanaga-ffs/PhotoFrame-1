using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class AddKeyword
    {
        private RepositoryMaster repositoryMaster;

        public AddKeyword(RepositoryMaster repositoryMaster)
        {
            this.repositoryMaster = repositoryMaster;
        }

        public bool Execute(string keyword, IEnumerable<Photo> photos)
        {


            return true;
        }
    }
}
