using System;
using System.Linq;
using MediaLibrary.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class SupprimerMediaTests
    {
        [TestMethod]
        public void SupprimerMedia_Successful()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                //ARRANGE
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                var media2 = new MediaTO { Name = "C# pour les nulls", Type = MediaType.Book, Path = "C:/Book/Code" };
                var media3 = new MediaTO { Name = "The IT Crowd", Type = MediaType.Serie, Path = "C:/Films/Series" };
                var result = mediaRepo.CreerMedia(media);
                var result2 = mediaRepo.CreerMedia(media2);
                var result3 = mediaRepo.CreerMedia(media3);
                context.SaveChanges();

                //ACT
                var test = mediaRepo.SupprimerMedia(result);
                context.SaveChanges();

                //ASSERT
                Assert.AreEqual(2, context.Medias.Count());
            }
        }
    }
}
