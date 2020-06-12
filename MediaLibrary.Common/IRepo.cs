using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibrary.Common
{
    public interface IRepo : IDisposable
    {
        MediaTO CreerMedia(MediaTO entity);
        MediaTO ModifierMedia(MediaTO entity);
        MediaTO SupprimerMedia(MediaTO entity);
        List<MediaTO> ObtenirTousMedias();
    }
}
