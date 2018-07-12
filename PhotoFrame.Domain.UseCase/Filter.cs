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
        private readonly RepositoryMaster repositoryMaster;

        public Filter(RepositoryMaster repositoryMaster)
        {
            this.repositoryMaster = repositoryMaster;
        }

        public IEnumerable<Photo> Execute(string keyword, bool isFavorite, DateTime firstDate, DateTime lastDate)
        {
            DateTime defaultDate = new DateTime();

            IEnumerable<Photo> photos = repositoryMaster.Filter((Photo photo) => true);

            if(keyword != null && keyword != "")
            {
                photos = repositoryMaster.Filter(((Photo photo) => photo.Keywords.Contains(keyword)), photos);
            }

            if (isFavorite)
            {
                photos = repositoryMaster.Filter(((Photo photo) => photo.IsFavorite), photos);
            }

            if(firstDate != defaultDate && lastDate != defaultDate && firstDate <= lastDate)
            {
                photos = repositoryMaster.Filter(((Photo photo) => (photo.Date.Date >= firstDate.Date && photo.Date.Date <= lastDate.Date.Date)), photos);
            }
            else if(firstDate != defaultDate && lastDate == defaultDate)
            {
                photos = repositoryMaster.Filter(((Photo photo) => (photo.Date.Date >= firstDate.Date)), photos);
            }
            else if(firstDate == defaultDate && lastDate != defaultDate)
            {
                photos = repositoryMaster.Filter(((Photo photo) => (photo.Date.Date <= lastDate.Date)), photos);
            }

            return photos;
        }
    }
}
