using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Homework3.Models;
using System.Collections.Generic;



namespace Homework3.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/App_Data/Images/"));

            List<FileModel> files = new List<FileModel>();

            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }
            return View(files);
            }

        public ActionResult Downloadimage(string Imagename)
        {
            //Build the File Path.

            string path = Server.MapPath("~/App_Data/Images/") + Imagename;

            //Read the File data into Byte Array.
            //Use a byte array becasue of octet-stream.

            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", Imagename);
        }

        public ActionResult DeleteImage(string Imagename)
        {
            //Delete requires reading the files and then the allocation of a file path.
            //The file is then deleted based on the identified file path.

            string path = Server.MapPath("~/App_Data/Images/") + Imagename;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            System.IO.File.Delete(path);
            return RedirectToAction("Index");
        }

    }
    }
