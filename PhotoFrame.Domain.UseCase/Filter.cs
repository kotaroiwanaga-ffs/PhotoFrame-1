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

        /// <summary>
        /// RepositoryMasterの保持するフォトリストのうち条件に合うものだけを返す(絞り込み)
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="isFavorite"></param>
        /// <param name="firstDate"></param>
        /// <param name="lastDate"></param>
        /// <returns></returns>
        public IEnumerable<Photo> Execute(string keyword, bool isFavorite, DateTime firstDate, DateTime lastDate)
        {
            DateTime defaultDate = new DateTime();

            IEnumerable<Photo> photos = repositoryMaster.Filter((Photo photo) => true);

            // キーワード絞り込み
            if(keyword != null && keyword != "")
            {
                photos = repositoryMaster.Filter(((Photo photo) => photo.Keywords.Contains(keyword)), photos);
            }

            // お気に入り絞り込み
            if (isFavorite)
            {
                photos = repositoryMaster.Filter(((Photo photo) => photo.IsFavorite), photos);
            }

            // 撮影日時絞り込み
            // 開始日・終了日入力あり
            if(firstDate != defaultDate && lastDate != defaultDate && firstDate <= lastDate)
            {
                photos = repositoryMaster.Filter(((Photo photo) => (photo.Date.Date >= firstDate.Date && photo.Date.Date <= lastDate.Date.Date)), photos);
            }
            // 開始日のみ入力
            else if(firstDate != defaultDate && lastDate == defaultDate)
            {
                photos = repositoryMaster.Filter(((Photo photo) => (photo.Date != defaultDate && photo.Date.Date >= firstDate.Date)), photos);
            }
            // 終了日のみ入力
            else if(firstDate == defaultDate && lastDate != defaultDate)
            {
                photos = repositoryMaster.Filter(((Photo photo) => (photo.Date != defaultDate && photo.Date.Date <= lastDate.Date)), photos);
            }

            return photos;
        }
    }
}
