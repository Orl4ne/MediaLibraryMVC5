using System;
using MediaLibrary.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class ModifierMediaTests
    {
        [TestMethod]
        public void ModifierMedia_Successful()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using (var context = new MediaLibraryContext(connection))
            {
                IRepo mediaRepo = new MediaRepo(context);
                //ARRANGE
                var media = new MediaTO { Name = "Cendrillon", Type = MediaType.Film, Path = "C:/Films/Animation" };
                var result = mediaRepo.CreerMedia(media);
                context.SaveChanges();

                //ACT
                result.Name = "Cendrillon Remaster";
                var test = mediaRepo.ModifierMedia(result);
                context.SaveChanges();

                //ASSERT
                Assert.AreEqual("Cendrillon Remaster", test.Name);
            }
        }
    }
}
