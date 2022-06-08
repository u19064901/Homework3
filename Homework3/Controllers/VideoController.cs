using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Collections.Generic;
using Homework3.Models;

namespace Homework3.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Videos/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
        }
        public ActionResult DownloadVideo(string VideoName)
        {
            //Build the File Path.

            string path = Server.MapPath("~/App_Data/Videos/") + VideoName;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", VideoName);
        }

        public ActionResult DeleteVideo(string VideoName)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/App_Data/Images/") + VideoName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);
            return RedirectToAction("Index");
        }
    } 
}