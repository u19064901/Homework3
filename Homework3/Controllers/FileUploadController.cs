using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Homework3.Controllers
{
    public class FileUploadController : Controller
    {
        // GET: FileUpload
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //Single File Upload
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files)
        {
            if (files != null && files.ContentLength > 0)
            {
                // extract only the filename

                var fileName = Path.GetFileName(files.FileName);

                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);

                // The chosen default path for saving

                files.SaveAs(path);
            }

            return RedirectToAction("Index"); 
        }
    }
}