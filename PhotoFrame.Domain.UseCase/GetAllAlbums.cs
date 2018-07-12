using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class GetAllAlbums
    {
        private readonly RepositoryMaster repositoryMaster;

        public GetAllAlbums(RepositoryMaster repositoryMaster)
        {
            this.repositoryMaster = repositoryMaster;
        }

        public IEnumerable<Album> Execute()
        {
            return repositoryMaster.FindAlbum((allAlbums) => allAlbums);
 
        }
    }
}
