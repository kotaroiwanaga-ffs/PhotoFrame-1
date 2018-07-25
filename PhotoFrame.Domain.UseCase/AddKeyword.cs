﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class AddKeyword
    {
        private RepositoryMaster repositoryMaster;

        public AddKeyword(RepositoryMaster repositoryMaster)
        {
            this.repositoryMaster = repositoryMaster;
        }

        /// <summary>
        /// photosの各要素に指定したキーワードを追加する
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="photos"></param>
        /// <returns>photosのうち一つでもキーワード追加が成功したらtrue</returns>
        public bool Execute(string keyword, IEnumerable<Photo> photos)
        {
            bool success = false;

            foreach(Photo photo in photos)
            {
                if (photo.AddKeyword(keyword))
                {
                    repositoryMaster.StorePhoto(photo);
                    success = true;
                }
            }

            return success;
        }
    }
}
