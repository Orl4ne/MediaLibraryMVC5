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
        public MediaTO CreateMedia(MediaTO entity)
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

        public MediaTO ModifyMedia(MediaTO entity)
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
                entity.ToTrackedEF(editedEntity);
            }
            context.SaveChanges();

            return editedEntity.ToTransferObject();
        }

        public List<MediaTO> GetAllMedias()
        {

            var list =  context.Medias.AsEnumerable()
                 ?.Select(x => x.ToTransferObject())
                 .ToList();
            if (!list.Any())
            {
                throw new ArgumentNullException("There is no Media in DB");
            }
            return list;
        }

        public bool DeleteMedia(MediaTO entity)
        {
            if (entity is null)
            {
                throw new KeyNotFoundException();
            }
            if (entity.Id <= 0)
            {
                throw new ArgumentException("Media To Delete Invalid Id");
            }

            var media = context.Medias.FirstOrDefault(x => x.Id == entity.Id);
            context.Medias.Remove(media);
            context.SaveChanges();
            return true;

        }

        public MediaTO GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Media not found, invalid Id");
            }
            return context.Medias.FirstOrDefault(x => x.Id == id).ToTransferObject();


        }
    }
}
