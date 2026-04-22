using Microsoft.AspNetCore.Mvc;
using MvcComicsDocker.Models;
using MvcComicsDocker.Repositories;

namespace MvcComicsDocker.Controllers
{
    public class ComicsController : Controller
    {
        private RepositoryComics repo;

        public ComicsController(RepositoryComics repo)
        {
            this.repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            List<Comic> comics = await repo.GetComicsAsync();
            return View(comics);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comic comic)
        {
            await repo.CreateComicAsync(comic.Nombre, comic.Imagen);
            ViewData["mensaje"] = "Comic insertado";
            return RedirectToAction("Index");
        }
    }
}
