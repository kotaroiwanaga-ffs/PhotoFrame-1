﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;

namespace PhotoFrame.Domain.UseCase
{
    public class SortDateDescending
    {
        public IEnumerable<Photo> Execute(IEnumerable<Photo> photos)
        {
            return photos.OrderByDescending(p => p.Date);
        }
    }
}
