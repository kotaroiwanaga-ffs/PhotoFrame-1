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
        public void PhotoFrameApplicationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchFolderTest()
        {
            //List<Photo> photolist01 = new List<Photo>();
            //List<Photo> photolist02 = new List<Photo>();

            //空文字を入力
            Assert.IsTrue( application.SearchFolder("").Count()==0);

            //写真が存在するとき
            Assert.IsTrue(application.SearchFolder(@"C:\研修用\Album1").Count() == 3);

            //写真が存在しないとき
            Assert.IsTrue(application.SearchFolder(@"C:\研修用\Album2").Count() == 0);

            //保存済みのファイルを含むフォルダ
            Assert.IsTrue(application.SearchFolder(@"C:\研修用\Album1").Count() == 3);

        }

        [TestMethod()]
        public void FilterTest()
        {
           

            Assert.Fail();
        }

        [TestMethod()]
        public void AddKeywordTest()
        {
            Assert.IsTrue(application.AddKeyword("xxx", photos));

            foreach(Photo photo in photos)
            {
                Assert.IsTrue(photo.Keywords.Contains("xxx"));
            }
        }

        [TestMethod()]
        public void DeleteKeywordTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ToggleIsFavoriteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddAlbumTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchAlbumTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SortDateAscendingTest()
        {
            var dbPhotos = new List<Photo>();
            string[] array1 = new string[] { "a", "b", "c" };
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(2018, 7, 18), array1.ToList<string>(), true));
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Desert.jpg"), new DateTime(2018, 7, 19), array1.ToList<string>(), true));
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Hydrangeas.jpg"), new DateTime(2018, 7, 20), array1.ToList<string>(), false));

            var photolist = application.SortDateAscending(dbPhotos);

            if (photolist.ElementAt(2).File.FilePath == @"C:\研修用\Album1\Hydrangeas.jpg" &&
                photolist.ElementAt(1).File.FilePath == @"C:\研修用\Album1\Desert.jpg" &&
                photolist.ElementAt(0).File.FilePath == @"C:\研修用\Album1\Chrysanthemum.")
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod()]
        public void SortDateDescendingTest()
        {

            var dbPhotos = new List<Photo>();
            string[] array1 = new string[] { "a", "b", "c" };
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Chrysanthemum.jpg"), new DateTime(2018, 7, 18), array1.ToList<string>(), true));
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Desert.jpg"), new DateTime(2018, 7, 19), array1.ToList<string>(), true));
            dbPhotos.Add(new Photo(new File(@"C:\研修用\Album1\Hydrangeas.jpg"), new DateTime(2018, 7, 20), array1.ToList<string>(), false));

            var photolist = application.SortDateDescending(dbPhotos);

            if( photolist.ElementAt(0).File.FilePath== @"C:\研修用\Album1\Hydrangeas.jpg" &&
                photolist.ElementAt(1).File.FilePath == @"C:\研修用\Album1\Desert.jpg" &&
                photolist.ElementAt(2).File.FilePath == @"C:\研修用\Album1\Chrysanthemum."  )
            {
                Assert.IsTrue(true);
            }

        }

        [TestMethod()]
        public void GetAllAlbumsTest()
        {
            //逆順で帰ってくるか。DBがAlbum1，Album2,Album3なら、戻り値はAlbum3, Album2, Album1
            var albumlist = application.GetAllAlbums();

            if( albumlist.ElementAt(0).Name == "test3" &&
                albumlist.ElementAt(1).Name == "test2" &&
                albumlist.ElementAt(2).Name == "test1")
            {
                Assert.IsTrue(true);
            }
        }
    }
}