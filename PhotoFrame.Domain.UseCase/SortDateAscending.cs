using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SortDateAscending
    {
        public IEnumerable<Photo> Execute(IEnumerable<Photo> photos)
        {
            DateTime defaultDate = new DateTime();

            var tempPhotos = photos.Where(p => p.Date != defaultDate).OrderBy(p => p.Date).ToList();
            var defaultPhotos = photos.Where(p => p.Date == defaultDate);

            foreach (Photo photo in defaultPhotos)
            {
                tempPhotos.Add(photo);
            }

            return tempPhotos;
        }
    }
}
