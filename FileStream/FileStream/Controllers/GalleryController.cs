using FileStream.Database;
using FileStream.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FileStream.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Upload()
        {
            return View();
        }

        [Route("Upload")]
        [HttpPost]
        public ActionResult Upload(Gallery model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            Repository service = new Repository();
            int i = service.SaveImage(file);
            if (i == 1)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

    }
}