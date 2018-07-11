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
        //private readonly IPhotoRepository photoRepository;

        //public SearchAlbum(IPhotoRepository photoRepository)
        //{
        //    this.photoRepository = photoRepository;
        //}

        public IEnumerable<Photo> Execute(string albumName)
        {
            List<Photo> photos = new List<Photo>();

            return photos;
        }

        //public async Task<IEnumerable<Photo>> ExecuteAsync(string albumName)
        //{
        //    return await Task.Run(() => photoRepository.Find(photos => (from p in photos where p.Album != null && p.Album.Name == albumName select p).ToList().AsQueryable()));
        //}
    }
}
