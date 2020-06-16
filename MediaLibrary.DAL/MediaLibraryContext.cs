using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.DAL
{
    public class MediaLibraryContext : DbContext
    {
        public MediaLibraryContext() : base("MediaLibraryDb")
        {
        }
        public MediaLibraryContext(DbConnection connection) : base(connection, false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MediaEF> Medias { get; set; }
    }
}
