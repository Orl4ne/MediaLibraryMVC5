using MediaLibrary.Common;
using MediaLibrary.DAL;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MediaLibrary.Web.Controllers
{
    public class MediaController : Controller
    {
        private MediaRepo mediaRepo { get; set; }
        public MediaController()
        {
            mediaRepo = new MediaRepo(new MediaLibraryContext());
        }

        // GET: Media
        public ActionResult Index()
        {
            var medias = mediaRepo.ObtenirTousMedias();
            return View(medias);
        }

        // GET: Media/Details/5
        public ActionResult Details(int id)
        {
            var media = mediaRepo.GetById(id);
            return View(media);
        }

        // GET: Media/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        [HttpPost]
        public ActionResult Create(MediaTO media)
        {
            try
            {
                mediaRepo.CreerMedia(media);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Media/Edit/5
        public ActionResult Edit(int id)
        {
            var mediaToEdit = mediaRepo.GetById(id);
            return View(mediaToEdit);
        }

        // POST: Media/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MediaTO media)
        {
            try
            {
                mediaRepo.ModifierMedia(media);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Media/Delete/5
        public ActionResult Delete(int id)
        {
            var mediToDelete = mediaRepo.GetById(id);
            return View(mediToDelete);
        }

        // POST: Media/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, MediaTO media)
        {
            try
            {
                mediaRepo.SupprimerMedia(media);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
