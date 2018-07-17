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
            Assert.IsTrue(application.SearchFolder(@"C:\研修用\Album2").Count() == 3);

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
            Assert.Fail();
        }

        [TestMethod()]
        public void SortDateDescendingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllAlbumsTest()
        {
            var albumlist = application.GetAllAlbums();

            if(albumlist.Count
        }
    }
}