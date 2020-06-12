using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Common
{
    public class MediaTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public MediaType Type { get; set; }
    }
}
