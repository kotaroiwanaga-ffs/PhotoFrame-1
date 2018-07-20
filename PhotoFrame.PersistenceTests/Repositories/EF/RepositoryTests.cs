using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoFrame.Domain.Model;
using PhotoFrame.Persistence.EF;
using PhotoFrame.Persistence.Repositories.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoFrame.Persistence.Tests
{
    [TestClass()]
    public class RepositoryTests
    {
        PhotoRepository photoRepository = new PhotoRepository();
        AlbumRepository albumRepository = new AlbumRepository();
        SlideShowRepository slideshowRepository = new SlideShowRepository();

        [TestMethod()]
        public void フォルダ内の画像をリストビューに表示()
        {
            var result = photoRepository.Find(photos => photos.Where(
                photo => photo.File.FilePath.Contains("C://Test1/")
                ));
            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod()]
        public void 検索条件でリストビューにフィルタリング()
        {
            var result = photoRepository.Find(photos => photos.Where(
                photo => photo.File.FilePath.Contains("C://Test1/")
                && photo.IsFavorite == true
                ));
            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod()]
        public void お気に入りの登録1()
        {
            File testfile = new File("C://Test3/PhotoTest4.jpg");
            Photo testphoto = new Photo(testfile, new DateTime());
            testphoto.MarkAsFavorite();
            photoRepository.Store(testphoto);
        }

        [TestMethod()]
        public void お気に入りの登録2()
        {
            File testfile = new File("C://Test3/PhotoTest5.jpg");
            Photo testphoto = new Photo(testfile, new DateTime());
            testphoto.MarkAsFavorite();
            photoRepository.Store(testphoto);
            //テスト終わるとPhotoTest5.jpgのデータをDBから削除すること
        }

        [TestMethod()]
        public void お気に入り解除1()
        {
            File testfile = new File("C://Test3/PhotoTest4.jpg");
            Photo testphoto = new Photo(testfile, new DateTime(),null,true);
            testphoto.MarkAsUnFavorite();
            photoRepository.Store(testphoto);
        }

        [TestMethod()]
        public void お気に入り解除2()
        {
            File testfile = new File("C://Test3/PhotoTest5.jpg");
            Photo testphoto = new Photo(testfile, new DateTime(), null, true);
            testphoto.MarkAsUnFavorite();
            photoRepository.Store(testphoto);
            //テスト終わるとPhotoTest5.jpgのデータをDBから削除すること
        }

        [TestMethod()]
        public void キーワードの登録1()
        {
            File testfile = new File("C://Test3/PhotoTest4.jpg");
            Photo testphoto = new Photo(testfile, new DateTime(), null);
            testphoto.AddKeyword("aaa");
            photoRepository.Store(testphoto);
        }

        [TestMethod()]
        public void キーワードの登録2()
        {
            File testfile = new File("C://Test3/PhotoTest5.jpg");
            Photo testphoto = new Photo(testfile, new DateTime(), null);
            testphoto.AddKeyword("aaa");
            photoRepository.Store(testphoto);
            //テスト終わるとPhotoTest5.jpgのデータをDBから削除すること
        }

        [TestMethod()]
        public void キーワードの削除1()
        {
            File testfile = new File("C://Test3/PhotoTest4.jpg");
            Photo testphoto = new Photo(testfile, new DateTime(), new string[] { "aaa" });
            testphoto.DeleteKeyword("aaa");
            photoRepository.Store(testphoto);
        }

        [TestMethod()]
        public void キーワードの削除2()
        {
            File testfile = new File("C://Test3/PhotoTest5.jpg");
            Photo testphoto = new Photo(testfile, new DateTime(), new string[] { "aaa" });
            testphoto.DeleteKeyword("aaa");
            photoRepository.Store(testphoto);
            //テスト終わるとPhotoTest5.jpgのデータをDBから削除すること
        }

        [TestMethod()]
        public void 保存されたアルバムの写真をスライドショーに設定()
        {
            Album album = new Album("", "AlbumTest1", "");
            var result = slideshowRepository.Find(album);
            Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod()]
        public void 新しいアルバム名を保存1()
        {
            File testfile = new File("C://Test3/PhotoTest4.jpg");
            Photo testphoto = new Photo(testfile, new DateTime());
            Album album = new Album("", "AlbumTest1", "");
            slideshowRepository.Store(album, testphoto);
            //テスト終わるとalbum,testphotoのデータをDBから削除すること
        }

        [TestMethod()]
        public void 新しいアルバム名を保存2()
        {
            File testfile = new File("C://Test3/PhotoTest5.jpg");
            Photo testphoto = new Photo(testfile, new DateTime());
            Album album = new Album("", "AlbumTest1", "");
            slideshowRepository.Store(album, testphoto);
            //テスト終わるとPhotoTest5.jpgのデータをDBから削除すること
            //テスト終わるとalbum,testphotoのデータをDBから削除すること
        }

        [TestMethod()]
        public void 新しいアルバム名を保存3()
        {
            File testfile = new File("C://Test3/PhotoTest4.jpg");
            Photo testphoto = new Photo(testfile, new DateTime());
            Album album = new Album("", "AlbumTest2", "");
            slideshowRepository.Store(album, testphoto);
            //テスト終わるとAlbumTest2のデータをDBから削除すること
            //テスト終わるとalbum,testphotoのデータをDBから削除すること
        }

        [TestMethod()]
        public void 新しいアルバム名を保存4()
        {
            File testfile = new File("C://Test3/PhotoTest5.jpg");
            Photo testphoto = new Photo(testfile, new DateTime());
            Album album = new Album("", "AlbumTest2", "");
            slideshowRepository.Store(album, testphoto);
            //テスト終わるとPhotoTest5.jpgのデータをDBから削除すること
            //テスト終わるとAlbumTest2のデータをDBから削除すること
            //テスト終わるとalbum,testphotoのデータをDBから削除すること
        }

        [TestMethod()]
        public void 千枚テスト()
        {
            for (int i = 0; i < 1000; i++)
            {
                string filepath = "PhotoTest" + i + ".jpg";
                File testfile = new File(filepath);
                Photo testphoto = new Photo(testfile, new DateTime());
                photoRepository.Store(testphoto);
            }
            //テスト終わるとすべての写真データをDBから削除すること
        }

        [TestMethod()]
        public void 二千枚テスト()
        {
            for (int i = 0; i < 2000; i++)
            {
                string filepath = "PhotoTest" + i + ".jpg";
                File testfile = new File(filepath);
                Photo testphoto = new Photo(testfile, new DateTime());
                photoRepository.Store(testphoto);
            }
            //テスト終わるとすべての写真データをDBから削除すること
        }
    }
}