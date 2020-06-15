using MediaLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaLibrary.Web.Models
{
    public class MediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public MediaType Type { get; set; }
    }
}