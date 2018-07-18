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
            // 空文字を入力
            Assert.IsTrue(application.SearchFolder("").Count() == 0);

            // 写真が存在するとき
            Assert.IsTrue(application.SearchFolder(@"Album1").Count() == 5);

            // 写真が存在しないとき
            Assert.IsTrue(application.SearchFolder(@"Album2").Count() == 0);

            // 保存済みのファイルを含むフォルダ
            Assert.IsTrue(application.SearchFolder(@"Album3").Count() == 3);

            // 存在しないフォルダ
            Assert.IsTrue(application.SearchFolder(@"Album4").Count() == 0);

        }

        [TestMethod()]
        public void FilterTest()
        {
            Assert.Fail();
        }





        [TestMethod()]
        public void AddKeywordTest1()
        {
            Assert.IsFalse(application.AddKeyword("a", photos.Take(2)));
            Assert.IsTrue(photos.ElementAt(0).Keywords.Contains("a") && photos.ElementAt(0).Keywords.Count() == 1);
            Assert.IsTrue(photos.ElementAt(1).Keywords.Contains("a") && photos.ElementAt(1).Keywords.Contains("b") && photos.ElementAt(1).Keywords.Count() == 2);
        }

        [TestMethod()]
        public void AddKeywordTest2()
        {
            Assert.IsTrue(application.AddKeyword("b", photos.Take(2)));
            Assert.IsTrue(photos.ElementAt(0).Keywords.Contains("a") && photos.ElementAt(0).Keywords.Contains("b") && photos.ElementAt(0).Keywords.Count() == 2);
            Assert.IsTrue(photos.ElementAt(1).Keywords.Contains("a") && photos.ElementAt(1).Keywords.Contains("b") && photos.ElementAt(1).Keywords.Count() == 2);
        }

        [TestMethod()]
        public void AddKeywordTest3()
        {
            Assert.IsTrue(application.AddKeyword("c", photos.Take(2)));
            Assert.IsTrue(photos.ElementAt(0).Keywords.Contains("a") && photos.ElementAt(0).Keywords.Contains("c") && photos.ElementAt(0).Keywords.Count() == 2);
            Assert.IsTrue(photos.ElementAt(1).Keywords.Contains("a") && photos.ElementAt(1).Keywords.Contains("b") && photos.ElementAt(1).Keywords.Contains("c") && photos.ElementAt(1).Keywords.Count() == 3);
        }

        [TestMethod()]
        public void AddKeywordTest4()
        {
            Assert.IsFalse(application.AddKeyword("a", photos.Take(2)));
            Assert.IsTrue(photos.ElementAt(0).Keywords.Contains("a") && photos.ElementAt(0).Keywords.Count() == 1);
            Assert.IsTrue(photos.ElementAt(1).Keywords.Contains("a") && photos.ElementAt(1).Keywords.Contains("b") && photos.ElementAt(1).Keywords.Contains("c") && photos.ElementAt(1).Keywords.Contains("d") && photos.ElementAt(1).Keywords.Contains("e") && photos.ElementAt(1).Keywords.Count() == 5);
        }

        [TestMethod()]
        public void AddKeywordTest5()
        {
            Assert.IsTrue(application.AddKeyword("b", photos.Take(2)));
            Assert.IsTrue(photos.ElementAt(0).Keywords.Contains("a") && photos.ElementAt(0).Keywords.Contains("b") && photos.ElementAt(0).Keywords.Count() == 2);
            Assert.IsTrue(photos.ElementAt(1).Keywords.Contains("a") && photos.ElementAt(1).Keywords.Contains("b") && photos.ElementAt(1).Keywords.Contains("c") && photos.ElementAt(1).Keywords.Contains("d") && photos.ElementAt(1).Keywords.Contains("e") && photos.ElementAt(1).Keywords.Count() == 5);
        }

        [TestMethod()]
        public void AddKeywordTest6()
        {
            Assert.IsTrue(application.AddKeyword("f", photos.Take(2)));
            Assert.IsTrue(photos.ElementAt(0).Keywords.Contains("a") && photos.ElementAt(0).Keywords.Contains("f") && photos.ElementAt(0).Keywords.Count() == 2);
            Assert.IsTrue(photos.ElementAt(1).Keywords.Contains("a") && photos.ElementAt(1).Keywords.Contains("b") && photos.ElementAt(1).Keywords.Contains("c") && photos.ElementAt(1).Keywords.Contains("d") && photos.ElementAt(1).Keywords.Contains("e") && photos.ElementAt(1).Keywords.Count() == 5);
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