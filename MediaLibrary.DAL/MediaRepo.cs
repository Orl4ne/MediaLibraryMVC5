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
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (entity.Id <= 0)
            {
                throw new ArgumentException("Media To Update Invalid Id");
            }
            if (!context.Medias.Any(x => x.Id == entity.Id))
            {
                throw new KeyNotFoundException($"Update(MediaTO) Can't find media to update.");
            }

            var editedEntity = context.Medias.FirstOrDefault(e => e.Id == entity.Id);
            if (editedEntity != default)
            {
                editedEntity = entity.ToEF();
            }
            context.SaveChanges();

            return editedEntity.ToTransferObject();
        }

        public List<MediaTO> ObtenirTousMedias()
        {
            return context.Medias.AsEnumerable()
                .Select(x => x.ToTransferObject())
                .ToList();
        }

        public bool SupprimerMedia(MediaTO entity)
        {
            var media = context.Medias.FirstOrDefault(x => x.Id == entity.Id);

            if (media is null)
            {
                throw new KeyNotFoundException();
            }
            try
            {
                context.Medias.Remove(media);
                context.SaveChanges();
                return true;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }
    }
}
