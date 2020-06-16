﻿using MediaLibrary.Common;
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
            return View();
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
            return View();
        }

        // POST: Media/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Media/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
