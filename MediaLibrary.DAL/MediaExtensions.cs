using MediaLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.DAL
{
    public static class MediaExtensions
    {
        public static MediaTO ToTransferObject(this MediaEF media)
        {
            if (media is null)
                throw new ArgumentNullException(nameof(media));

            return new MediaTO
            {
                Id = media.Id,
                Name = media.Name,
                Path = media.Path,
                Type = media.Type
            };
        }

        public static MediaEF ToEF(this MediaTO media)
        {
            if (media is null)
                throw new ArgumentNullException(nameof(media));

            return new MediaEF
            {
                Id = media.Id,
                Name = media.Name,
                Path = media.Path,
                Type = media.Type
            };
        }
    }
}
