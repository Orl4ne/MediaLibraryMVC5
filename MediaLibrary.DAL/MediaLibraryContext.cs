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
        public MediaLibraryContext()
        {
        }
        public MediaLibraryContext(DbConnection connection) : base(connection, false)
        {
        }
        public DbSet<MediaEF> Medias { get; set; }
    }
}
