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
            if (entity is null)
            {
                throw new ArgumentNullException();
            }
            if (entity.Id != 0)
            {
                return entity;
            }
            var entityEF = context.Medias.Add(entity.ToEF());
            context.SaveChanges();

            return entityEF.ToTransferObject();
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
            return context.Medias.AsEnumerable()
                .Select(x => x.ToTransferObject())
                .ToList();
        }

        public MediaTO SupprimerMedia(MediaTO entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (entity.Id <= 0)
            {
                throw new ArgumentException("Category To Update Invalid Id");
            }
            if (!context.Medias.Any(x => x.Id == entity.Id))
            {
                throw new KeyNotFoundException($"Update(CategoryTO) Can't find category to update.");
            }

            var editedEntity = context.Medias.FirstOrDefault(e => e.Id == entity.Id);
            if (editedEntity != default)
            {
                editedEntity = entity.ToEF();
            }
            context.SaveChanges();

            return editedEntity.ToTransferObject();
        }
    }
}
