using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;


namespace PhotoFrame.Domain.UseCase
{
    public class SearchAlbum
    {
        private readonly RepositoryMaster repositoryMaster;

        public SearchAlbum(RepositoryMaster repositoryMaster)
        {
            this.repositoryMaster = repositoryMaster;
        }

        public IEnumerable<Photo> Execute(string albumName)
        {


            return new List<Photo>();
        }
    }
}
