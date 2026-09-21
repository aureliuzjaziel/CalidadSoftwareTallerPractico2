using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerPractico.Services;

namespace TallerPractico.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        // GET: PokemonController
        public async Task<ActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 50) pageSize = 50; // limitar para evitar peticiones grandes

            var pokemons = await _pokemonService.GetPokemonsPage(page, pageSize);
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(pokemons);
        }

        // GET: PokemonController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var pokemon = await _pokemonService.GetPokemon(id);
            return View(pokemon);
        }

        // GET: PokemonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PokemonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PokemonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PokemonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PokemonController/Delete/5	
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
