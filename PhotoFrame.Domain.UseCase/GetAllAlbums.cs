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
            IEnumerable<Album> albums = repositoryMaster.FindAlbum((allAlbums) => allAlbums);
            List<Album> sortedAlbums = new List<Album>();
 
            for(int i = albums.Count() - 1; i >= 0; i--)
            {
                sortedAlbums.Add(albums.ElementAt(i));
            }

            return sortedAlbums;
        }
    }
}
