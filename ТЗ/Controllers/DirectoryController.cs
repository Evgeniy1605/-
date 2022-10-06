using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using ТЗ.Models;

namespace ТЗ.Controllers
{
    public class DirectoryController : Controller
    {
        public static List<DirectoryModel> Directories = new List<DirectoryModel>() { };

        private readonly IWebHostEnvironment _environment;
        public DirectoryController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }


        public IActionResult HomePage(DirectoryModel model)
        {
            if (model.Path != null)
            {
                Directories.Add(model);
            }
            return View(Directories);
        }
         
        
        public IActionResult Index()
        {
            var path = Path.Combine(_environment.WebRootPath,"lib", "Directory", "Creating Digital Images");
            string[] files = Directory.GetDirectories(path);
            DirectoryModel model = new DirectoryModel();
            model.ArrFiles = files;
            model.Name = Path.GetFileName(path);
            return View(model);
        }

        public IActionResult ReflactFile(string name)
        {
            string[] files = Directory.GetDirectories(name);
            DirectoryModel model = new DirectoryModel();
            model.ArrFiles = files;
            model.Name = Path.GetFileName(name);
            return View("Index", model);
        }


        public IActionResult InputPathOfDirectory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveDirectory(string path)
        {
            DirectoryModel NewDirectory = new DirectoryModel();
            NewDirectory.Path = path;

            return RedirectToAction("HomePage", NewDirectory);
                
        }


        [HttpPost]
        public IActionResult OpenDirectory(string path)
        {
            string[] files;
            try
            {
                files = Directory.GetDirectories(path);
                DirectoryModel model = new DirectoryModel();
                model.ArrFiles = files;
                model.Name = Path.GetFileName(path);
                return View("Index", model);



            }
            catch (Exception)
            {
                return View("WrongPath");
            }
        }

    }
}
