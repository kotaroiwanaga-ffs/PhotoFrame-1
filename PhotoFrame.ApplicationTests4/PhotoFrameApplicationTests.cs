using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoFrame.Domain.Model;


namespace PhotoFrame.Application.Tests
{
    [TestClass()]
    public class PhotoFrameApplicationTests
    {
        private PhotoFrameApplication application;
        private IEnumerable<Photo> photos;

        [TestInitialize]
        public void SetUp()
        {
            this.application = new PhotoFrameApplication();
            this.photos = application.SearchFolder("Album1");
        }

        [TestMethod()]
        public void SearchFolderTest()
        {
            // 空文字を入力
            Assert.IsTrue(application.SearchFolder("").Count() == 0);

            // フォルダパスを入力
            Assert.IsTrue(application.SearchFolder(@"Album1").Count() == 5);

        }

        [TestMethod()]
        [DataRow("", false, null, null, true, true, true)]
        [DataRow("a", false, null, null, true, false, true)]
        [DataRow("", true, null, null, true, true, false)]
        [DataRow("", false, "2008/03/13", null, false, true, true)]
        [DataRow("", false, null, "2008/03/25", false, true, true)]
        [DataRow("", false, "2008/3/13", "2008/03/25", false, true, true)]

        [DataRow("b", true, null, null, false, true, false)]
        [DataRow("a", false, "2008/3/13", "2008/03/25", false, false, true)]
        [DataRow("", true, "2008/3/13", "2008/03/25", false, true, false)]
        [DataRow("a", true, "2008/3/13", "2008/03/25", false, false, false)]
        [DataRow("b", true, "2008/3/13", "2008/03/25", false, true, false)]

        public void FilterTest(string keyword, bool isFavorite, string s_firstDate, string s_lastDate, bool hit0, bool hit1, bool hit2)
        {
            this.photos = application.SearchFolder("FilterAlbum");

            application.AddKeyword("a", photos.Take(1));
            application.AddKeyword("b", photos.Skip(1));
            application.AddKeyword("a", photos.Skip(2));
            application.ToggleIsFavorite(photos.Take(2));

            DateTime firstDate, lastDate;

            if (!DateTime.TryParse(s_firstDate, out firstDate))
            {
                firstDate = new DateTime();
            }

            if (!DateTime.TryParse(s_lastDate, out lastDate))
            {
                lastDate = new DateTime();
            }

            bool[] hits = { hit0, hit1, hit2 };

            IEnumerable<Photo> filteredPhotos = application.Filter(keyword, isFavorite, firstDate, lastDate);

            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i])
                {
                    Assert.IsTrue(filteredPhotos.Contains(this.photos.ElementAt(i)));
                }
                else
                {
                    Assert.IsFalse(filteredPhotos.Contains(this.photos.ElementAt(i)));
                }
            }

        }

        [TestMethod()]
        [DataRow("a")]
        [DataRow("b")]
        [DataRow("c")]
        [DataRow("f")]
        public void AddKeywordTest(string keyword)
        {
            //application.Store(new Photo(new File(@"Album1\Chrysanthemum.jpg"), new DateTime(), new string[] { "a" }));
            //application.Store(new Photo(new File(@"Album1\Desert.jpg"), new DateTime(), new string[] { "a", "b" }));
            //application.Store(new Photo(new File(@"Album1\Desert.jpg"), new DateTime(), new string[] { "a", "b", "c", "d", "e" }));

            this.photos = application.SearchFolder("Album1");
            int[] counts = { this.photos.ElementAt(0).Keywords.Count(), this.photos.ElementAt(1).Keywords.Count() };


            if ((photos.ElementAt(0).Keywords.Contains(keyword) || photos.ElementAt(0).Keywords.Count() >= 5) && (photos.ElementAt(1).Keywords.Contains(keyword) || photos.ElementAt(1).Keywords.Count() >= 5))
            {
                Assert.IsFalse(application.AddKeyword(keyword, photos.Take(2)));
                Assert.IsTrue(photos.ElementAt(0).Keywords.Count() == counts[0]);
                Assert.IsTrue(photos.ElementAt(1).Keywords.Count() == counts[1]);
            }
            else
            {

                if (photos.ElementAt(0).Keywords.Contains(keyword) || photos.ElementAt(0).Keywords.Count() >= 5)
                {
                    Assert.IsTrue(application.AddKeyword(keyword, photos.Take(2)));
                    Assert.IsTrue(photos.ElementAt(0).Keywords.Count() == counts[0]);
                    Assert.IsTrue(photos.ElementAt(1).Keywords.Contains(keyword));
                }
                else if (photos.ElementAt(1).Keywords.Contains(keyword) || photos.ElementAt(1).Keywords.Count() >= 5)
                {
                    Assert.IsTrue(application.AddKeyword(keyword, photos.Take(2)));
                    Assert.IsTrue(photos.ElementAt(0).Keywords.Contains(keyword));
                    Assert.IsTrue(photos.ElementAt(1).Keywords.Count() == counts[1]);
                }
                else
                {
                    Assert.IsTrue(application.AddKeyword(keyword, photos.Take(2)));
                    Assert.IsTrue(photos.ElementAt(0).Keywords.Contains(keyword));
                    Assert.IsTrue(photos.ElementAt(1).Keywords.Contains(keyword));
                }


            }


        }

        [TestMethod()]
        [DataRow("a")]
        [DataRow("b")]
        [DataRow("c")]
        public void DeleteKeywordTest(string keyword)
        {
            //application.Store(new Photo(new File(@"Album1\Chrysanthemum.jpg"), new DateTime(), new string[] { "a" }));
            //application.Store(new Photo(new File(@"Album1\Desert.jpg"), new DateTime(), new string[] { "a", "b" }));

            this.photos = application.SearchFolder("Album1");

            bool[] contains = { this.photos.ElementAt(0).Keywords.Contains(keyword), this.photos.ElementAt(1).Keywords.Contains(keyword) };
            int[] counts = { this.photos.ElementAt(0).Keywords.Count(), this.photos.ElementAt(1).Keywords.Count() };


            if (contains[0] || contains[1])
            {
                Assert.IsTrue(application.DeleteKeyword(keyword, this.photos.Take(2)));
            }
            else
            {
                Assert.IsFalse(application.DeleteKeyword(keyword, this.photos.Take(2)));
            }

            if (contains[0])
            {
                Assert.IsFalse(this.photos.ElementAt(0).Keywords.Contains(keyword));
            }
            else
            {
                Assert.IsTrue(photos.ElementAt(0).Keywords.Count() == counts[0]);
            }

            if (contains[1])
            {
                Assert.IsFalse(this.photos.ElementAt(1).Keywords.Contains(keyword));
            }
            else
            {
                Assert.IsTrue(photos.ElementAt(1).Keywords.Count() == counts[1]);
            }
        }

        [TestMethod()]
        [DataRow(true, true)]
        [DataRow(true, false)]
        [DataRow(false, false)]
        public void ToggleIsFavoriteTest(bool isFavorite0, bool isFavorite1)
        {
            //application.Store(new Photo(new File(@"Album1\Chrysanthemum.jpg"), new DateTime(), null, isFavorite0));
            //application.Store(new Photo(new File(@"Album1\Desert.jpg"), new DateTime(), null, isFavorite1));

            this.photos = application.SearchFolder("Album1");

            application.ToggleIsFavorite(this.photos.Take(2));

            if (isFavorite0 && isFavorite1)
            {
                foreach (Photo photo in photos.Take(2))
                {
                    Assert.IsFalse(photo.IsFavorite);
                }
            }
            else
            {
                foreach (Photo photo in photos.Take(2))
                {
                    Assert.IsTrue(photo.IsFavorite);
                }
            }
        }

        [TestMethod()]
        public void AddAlbumTest()
        {
            //application.Store(Album.Create("Album1"));

            Assert.IsFalse(application.AddAlbum("Album1", this.photos));
            Assert.IsTrue(application.AddAlbum("Album2", this.photos));
        }

        [TestMethod()]
        public void SearchAlbumTest()
        {
            Album album1 = Album.Create("Album1");
            Album album2 = Album.Create("Album2");

            List<Photo> tempPhotos = new List<Photo>();
            tempPhotos.Add(new Photo(new File(@"Album1\Chrysanthemum.jpg"), new DateTime()));
            tempPhotos.Add(new Photo(new File(@"Album1\Desert.jpg"), new DateTime()));
            tempPhotos.Add(new Photo(new File(@"Album1\Hydrangeas.jpg"), new DateTime()));

            //application.Store(album1);
            //application.Store(album2);
            //tempPhotos.ForEach(p => application.Store(p));
            //application.Store(album1, tempPhotos.Take(2));
            //application.Store(album2, tempPhotos.Skip(2));


            IEnumerable<Photo> photos = application.SearchAlbum(album1.Name);

            for (int i = 0; i < photos.Count(); i++)
            {
                Assert.AreEqual(photos.ElementAt(i).File.FilePath, tempPhotos.ElementAt(i).File.FilePath);
            }
        }

        [TestMethod()]
        public void SortDateAscendingTest()
        {
            List<Photo> photos = new List<Photo>();

            photos.Add(new Photo(new File(@"photo0.jpg"), new DateTime()));
            photos.Add(new Photo(new File(@"photo1.jpg"), DateTime.Parse("2008/03/14 13:59")));
            photos.Add(new Photo(new File(@"photo2.jpg"), DateTime.Parse("2008/03/24 16:41")));
            photos.Add(new Photo(new File(@"photo3.jpg"), DateTime.Parse("2008/02/11 11:32")));

            IEnumerable<Photo> sortedPhotos = application.SortDateAscending(photos);
            //int index;
            //DateTime defaultDate = new DateTime();

            //for (index = 0; index < sortedPhotos.Count(); index++)
            //{
            //    if (sortedPhotos.ElementAt(index).Date != defaultDate)
            //    {
            //        if (index >= 1)
            //        {
            //            Assert.IsTrue(sortedPhotos.ElementAt(index - 1).Date <= sortedPhotos.ElementAt(index).Date);
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //for (index = index; index < sortedPhotos.Count(); index++)
            //{
            //    Assert.IsTrue(sortedPhotos.ElementAt(index).Date == defaultDate);
            //}

            Assert.AreEqual(sortedPhotos.ElementAt(0).File.FilePath, @"photo3.jpg");
            Assert.AreEqual(sortedPhotos.ElementAt(1).File.FilePath, @"photo1.jpg");
            Assert.AreEqual(sortedPhotos.ElementAt(2).File.FilePath, @"photo2.jpg");
            Assert.AreEqual(sortedPhotos.ElementAt(3).File.FilePath, @"photo0.jpg");

        }

        [TestMethod()]
        public void SortDateDescendingTest()
        {
            List<Photo> photos = new List<Photo>();

            photos.Add(new Photo(new File(@"photo0.jpg"), new DateTime()));
            photos.Add(new Photo(new File(@"photo1.jpg"), DateTime.Parse("2008/02/11 11:32")));
            photos.Add(new Photo(new File(@"photo2.jpg"), DateTime.Parse("2008/03/24 16:41")));
            photos.Add(new Photo(new File(@"photo3.jpg"), DateTime.Parse("2008/03/14 13:59")));

            IEnumerable<Photo> sortedPhotos = application.SortDateDescending(photos);
            //int index;
            //DateTime defaultDate = new DateTime();

            //for(index = 0; index < sortedPhotos.Count(); index++)
            //{
            //    if(sortedPhotos.ElementAt(index).Date != defaultDate)
            //    {
            //        if(index >= 1)
            //        {
            //            Assert.IsTrue(sortedPhotos.ElementAt(index - 1).Date <= sortedPhotos.ElementAt(index).Date);
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //for(index = index; index < sortedPhotos.Count(); index++)
            //{
            //    Assert.IsTrue(sortedPhotos.ElementAt(index).Date == defaultDate);
            //}

            Assert.AreEqual(sortedPhotos.ElementAt(0).File.FilePath, @"photo2.jpg");
            Assert.AreEqual(sortedPhotos.ElementAt(1).File.FilePath, @"photo3.jpg");
            Assert.AreEqual(sortedPhotos.ElementAt(2).File.FilePath, @"photo1.jpg");
            Assert.AreEqual(sortedPhotos.ElementAt(3).File.FilePath, @"photo0.jpg");
        }

        [TestMethod()]
        public void GetAllAlbumsTest()
        {
            //逆順で帰ってくるか。DBがAlbum1，Album2,Album3なら、戻り値はAlbum3, Album2, Album1
            var albumlist = application.GetAllAlbums();

            if (albumlist.ElementAt(0).Name == "test3" &&
                albumlist.ElementAt(1).Name == "test2" &&
                albumlist.ElementAt(2).Name == "test1")
            {
                Assert.IsTrue(true);
            }
        }
    }
}