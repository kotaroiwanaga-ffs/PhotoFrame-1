using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;


namespace PhotoFrame.Domain.UseCase
{
    public class SearchFolder
    {
        private readonly RepositoryMaster repositoryMaster;

        public SearchFolder(RepositoryMaster repositoryMaster)
        {
            this.repositoryMaster = repositoryMaster;
        }

        public IEnumerable<Photo> Execute(string filePath)
        {
            List<Photo> photos = new List<Photo>();
            


            return photos;
        }
    }
}
