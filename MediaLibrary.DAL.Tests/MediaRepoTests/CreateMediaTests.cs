using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using MediaLibrary.Common;
using System.Linq;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class CreateMediaTests
    {
        [TestMethod]
        public void CreateMedia_Successful()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                //ACT
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                var result = mediaRepo.CreateMedia(media);
                context.SaveChanges();

                //ASSERT
                Assert.IsNotNull(result);
                Assert.AreEqual("Cendrillon", result.Name);
                Assert.AreEqual(1, result.Id);
            }
        }

        [TestMethod]
        public void CreateMedia_AddNull_ThrowException()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                Assert.ThrowsException<ArgumentNullException>(() => mediaRepo.CreateMedia(null));
            }
        }

        [TestMethod]
        public void CreateMedia_AddExistingMedia_DoNotInsertTwiceInDb()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                var addedMedia = mediaRepo.CreateMedia(media);
                context.SaveChanges();
                mediaRepo.CreateMedia(addedMedia);
                context.SaveChanges();

                Assert.AreEqual(1, context.Medias.Count());
            }
        }
    }
}
