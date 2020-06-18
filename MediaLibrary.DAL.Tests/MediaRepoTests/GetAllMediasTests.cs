using System;
using System.Linq;
using MediaLibrary.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class GetAllMediasTests
    {
        [TestMethod]
        public void GetALlMedias_Successful()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                //ARRANGE
                var media = new MediaTO {  Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                var media2 = new MediaTO { Name = "C# pour les nulls", Type = MediaType.Book, Path = "C:/Book/Code" };
                var media3 = new MediaTO { Name = "The IT Crowd", Type = MediaType.Serie, Path = "C:/Films/Series" };
                var result = mediaRepo.CreateMedia(media);
                var result2 = mediaRepo.CreateMedia(media2);
                var result3 = mediaRepo.CreateMedia(media3);
                context.SaveChanges();

                //ACT
                var test = mediaRepo.GetAllMedias();

                //ASSERT
                Assert.AreEqual(3, test.Count());
            }
        }

        [TestMethod]
        public void GetAllMedia_NoMediaInDb_ThrowException()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                
                Assert.ThrowsException<ArgumentNullException>(() => mediaRepo.GetAllMedias());
            }
        }
    }
}
