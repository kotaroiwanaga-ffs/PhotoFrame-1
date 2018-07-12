using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class Filter
    {
        public IEnumerable<Photo> Execute(string keyword, bool isFavorite, DateTime firstDate, DateTime lastDate)
        {
            Func<Photo, bool> query = ((photo) =>
            {
                
            });



            List<Photo> photos = new List<Photo>();



            return photos;
        }
    }
}
