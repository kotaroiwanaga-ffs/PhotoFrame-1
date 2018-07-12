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

        [TestInitialize]
        public void SetUp()
        {
            application = new PhotoFrameApplication();
            application.SearchFolder("Album1");
        }

        [TestMethod()]
        public void PhotoFrameApplicationTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SearchFolderTest()
        {
            IEnumerable<Photo> photos = application.SearchFolder("Album2");

            Assert.IsTrue(photos.Count() == 3);
            Assert.AreEqual(photos.ElementAt(2).File.FilePath, @"Album2\Tulips.jpg");
            Assert.AreEqual(photos.ElementAt(2).Date, new DateTime());
        }

        [TestMethod()]
        public void FilterTest()
        {
           

            Assert.Fail();
        }

        [TestMethod()]
        public void AddKeywordTest()
        {
            Assert.Fail();
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
            Assert.Fail();
        }
    }
}