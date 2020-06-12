using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MediaLibrary.DAL.Tests.MediaRepoTests
{
    [TestClass]
    public class CreerMediaTests
    {
        [TestMethod]
        public void CreerMedia_Successful()
        {
            var connection = Effort.DbConnectionFactory.CreateTransient();
            using var ctxt = new MediaContext(connection);


        }
    }
}
