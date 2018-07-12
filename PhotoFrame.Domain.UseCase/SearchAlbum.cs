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
            List<Photo> photos = new List<Photo>();
            IEnumerable<string> pathlist = repositoryMaster.FindSlideShow(Album.Create(albumName));

            foreach(string path in pathlist)
            {
                Func<IQueryable<Photo>, Photo> query = ((allPhotos) =>
                {
                    return allPhotos
                        .Where(p => p.File.FilePath == path)
                        .FirstOrDefault();
                });

                photos.Add(repositoryMaster.FindPhoto(query));
            }

            return photos;
        }
    }
}
