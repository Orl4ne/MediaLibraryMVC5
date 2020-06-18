using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Common
{
    public interface IRepo : IDisposable
    {
        MediaTO CreateMedia(MediaTO entity);
        MediaTO ModifyMedia(MediaTO entity);
        bool DeleteMedia(MediaTO entity);
        List<MediaTO> GetAllMedias();
        MediaTO GetById(int id);
    }
}
