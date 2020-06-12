using MediaLibrary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.DAL
{
    public class MediaRepo : IRepo
    {
        private MediaLibraryContext context;
        public MediaRepo(MediaLibraryContext context)
        {
            this.context = context;
        }
        public void Dispose()
        {
            context.Dispose();
        }
        public MediaTO CreerMedia(MediaTO entity)
        {
            return context.Medias.Add(entity.ToEF()).ToTransferObject();
        }

        public MediaTO ModifierMedia(MediaTO entity)
        {
            var entityEF = entity.ToEF();
            var mediaFound = context.Medias.FirstOrDefault(media => media.Id == entityEF.Id);
            if (mediaFound != null)
            {
                mediaFound.Name = entityEF.Name;
                mediaFound.Path = entityEF.Path;
                mediaFound.Type = entityEF.Type;
                context.SaveChanges();
            }
            return mediaFound.ToTransferObject();
        }

        public List<MediaTO> ObtenirTousMedias()
        {
            return context.Medias.Select(m => m.ToTransferObject()).ToList();
        }

        public MediaTO SupprimerMedia(MediaTO entity)
        {
            return context.Medias.FirstOrDefault(media => media.Id == entity.Id).ToTransferObject();
        }
    }
}
