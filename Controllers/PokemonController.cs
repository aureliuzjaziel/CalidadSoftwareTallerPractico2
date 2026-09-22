using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TallerPractico.Services;
using System.Collections.Generic;
using System.Linq;

namespace TallerPractico.Controllers
{
    public class PokemonController : Controller
    {
        private readonly PokemonService _pokemonService;

        public PokemonController(PokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<ActionResult> Index(int page = 1, int pageSize = 10)
        {
            if (page < 1) page = 1;
            if (pageSize < 1) pageSize = 10;
            if (pageSize > 50) pageSize = 50;

            var pokemons = await _pokemonService.GetPokemonsPage(page, pageSize);
            ViewBag.Page = page;
            ViewBag.PageSize = pageSize;
            return View(pokemons);
        }


        public async Task<ActionResult> Details(int id)
        {
            var pokemon = await _pokemonService.GetPokemon(id);
            return View(pokemon);
        }


        public ActionResult Sample()
        {

            var list = new List<TallerPractico.Models.Pokemon>
            {
                new TallerPractico.Models.Pokemon {
                    Id = 1, Name = "bulbasaur", Height = "7", Weight = "69", Order = 1,
                    Sprites = new TallerPractico.Models.PokemonSprites { Front_Default = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png", Back_Default = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/1.png", Front_Shiny = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/1.png" },
                    TypeNames = new List<string> { "grass", "poison" },
                    AbilityNames = new List<string> { "overgrow", "chlorophyll" }
                },
                new TallerPractico.Models.Pokemon {
                    Id = 4, Name = "charmander", Height = "6", Weight = "85", Order = 4,
                    Sprites = new TallerPractico.Models.PokemonSprites { Front_Default = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png", Back_Default = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/4.png", Front_Shiny = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/4.png" },
                    TypeNames = new List<string> { "fire" },
                    AbilityNames = new List<string> { "blaze", "solar-power" }
                },
                new TallerPractico.Models.Pokemon {
                    Id = 7, Name = "squirtle", Height = "5", Weight = "90", Order = 7,
                    Sprites = new TallerPractico.Models.PokemonSprites { Front_Default = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png", Back_Default = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/7.png", Front_Shiny = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/7.png" },
                    TypeNames = new List<string> { "water" },
                    AbilityNames = new List<string> { "torrent", "rain-dish" }
                },
                new TallerPractico.Models.Pokemon {
                    Id = 25, Name = "pikachu", Height = "4", Weight = "60", Order = 25,
                    Sprites = new TallerPractico.Models.PokemonSprites { Front_Default = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png", Back_Default = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/back/25.png", Front_Shiny = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/shiny/25.png" },
                    TypeNames = new List<string> { "electric" },
                    AbilityNames = new List<string> { "static", "lightning-rod" }
                }
            };

            // Populate images for demo items
            foreach (var p in list)
            {
                var images = new List<string>();
                if (!string.IsNullOrEmpty(p.Sprites?.Front_Default)) images.Add(p.Sprites.Front_Default);
                if (!string.IsNullOrEmpty(p.Sprites?.Back_Default)) images.Add(p.Sprites.Back_Default);
                if (!string.IsNullOrEmpty(p.Sprites?.Front_Shiny)) images.Add(p.Sprites.Front_Shiny);
                p.Images = images.Distinct().ToList();
            }

            return View(list);
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
