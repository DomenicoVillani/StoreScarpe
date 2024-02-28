using Microsoft.AspNetCore.Mvc;
using Scarpe.Models;

namespace Scarpe.Controllers
{
    public class ArticoloController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(DB.GetAll());
        }

        [HttpGet]
        public IActionResult Dettagli([FromRoute] int? id)
        {
            if(id.HasValue)
            {
                var articolo = DB.GetById(id);
                if(articolo is null)
                {
                    return View("Error");
                }
                else
                {
                    return View(articolo);
                }
            }
            return RedirectToAction("Index","Articolo");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(string name, int prezzo , string description, string imgCover, string imgDetails1, string imgDetails2)
        {
            Articolo articolo = new Articolo();
            articolo.Name = name;
            articolo.Prezzo = prezzo;
            articolo.Description = description;
            articolo.ImgCover = imgCover;
            if (articolo.ImgDetails == null)
            {
                articolo.ImgDetails = new List<string>();
            }
            articolo.ImgDetails.Insert(0,imgDetails1);
            articolo.ImgDetails.Insert(1, imgDetails2);
            DB.Add(articolo);
            return RedirectToAction("Dettagli", new {id = articolo.Id});
        }

    }
}
