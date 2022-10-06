using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.IO;
using ТЗ.Models;

namespace ТЗ.Controllers
{
    public class DirectoryController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        public DirectoryController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

         
        public IActionResult Index()
        {
            var path = Path.Combine(_environment.WebRootPath, "Directory");
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

        [HttpPost]
        public IActionResult GetRepositiry( List<IFileInfo> File)
        {

            
            return View("Index");
        }
    }
}
