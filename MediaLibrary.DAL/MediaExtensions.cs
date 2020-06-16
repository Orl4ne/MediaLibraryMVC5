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
        public static MediaEF ToTrackedEF(this MediaTO media, MediaEF mediaToModify )
        {
            if (mediaToModify is null)
                throw new ArgumentNullException(nameof(mediaToModify));
            if (media is null)
                throw new ArgumentNullException(nameof(media));

            mediaToModify.Id = media.Id;
            mediaToModify.Name = media.Name;
            mediaToModify.Type = media.Type;
            mediaToModify.Path = media.Path;

            return mediaToModify;    
            
        }
    }
}
