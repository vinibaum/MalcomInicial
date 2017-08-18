using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webSiteInicial.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var fotos = Directory.EnumerateFiles(Server.MapPath("~/Fotos"));



            return View(fotos);
        }
        public IEnumerable<string> GetFilesOnFolder()
        {
            string dirPath = Path.Combine(ConfigurationManager.AppSettings["DiretorioFotos"].ToString());
            List<string> files = new List<string>();
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            foreach (FileInfo fInfo in dirInfo.GetFiles())
            {
                files.Add(fInfo.Name);
            }
            return files.ToArray();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Narcos pump.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Fali conos cu.";

            return View();
        }
    }
}