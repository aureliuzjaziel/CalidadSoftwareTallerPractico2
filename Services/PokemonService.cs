using Newtonsoft.Json;
using TallerPractico.Models;

namespace TallerPractico.Services
{
    public class PokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon?> GetPokemon(string name)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{name}");
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(response);
            if (pokemon != null)
            {
                PopulateImages(pokemon);
                PopulateTypesAndAbilities(pokemon);
                return pokemon;
            }
            return new Pokemon();
        }
        public async Task<Pokemon?> GetPokemon(int id)
        {
            var response = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon/{id}");
            var pokemon = JsonConvert.DeserializeObject<Pokemon>(response);
            if (pokemon != null)
            {
                PopulateImages(pokemon);
                PopulateTypesAndAbilities(pokemon);
                return pokemon;
            }
            return new Pokemon();
        }


        public async Task<List<Pokemon>> GetPokemons(int offset = 0, int limit = 20)
        {
            var apiResponse = await _httpClient.GetStringAsync($"https://pokeapi.co/api/v2/pokemon?offset={offset}&limit={limit}");
            var pokemonsResponse = JsonConvert.DeserializeObject<APIResponse>(apiResponse);
            var pokemons = new List<Pokemon>();
            foreach (var pokemon in pokemonsResponse?.Results)
            {
                pokemons.Add(await GetPokemon(pokemon.Name));
            }
            return pokemons;
        }

        // Helper: obtener por página (número de página, tamaño por página)
        public Task<List<Pokemon>> GetPokemonsPage(int page = 1, int pageSize = 20)
        {
            if (page < 1) page = 1;
            var offset = (page - 1) * pageSize;
            return GetPokemons(offset, pageSize);
        }

        // Rellena la lista Images del Pokemon con todas las URLs no nulas encontradas en Sprites
        private void PopulateImages(Pokemon pokemon)
        {
            var images = new List<string>();
            void Collect(PokemonSprites s)
            {
                if (s == null) return;
                if (!string.IsNullOrEmpty(s.Front_Default)) images.Add(s.Front_Default);
                if (!string.IsNullOrEmpty(s.Back_Default)) images.Add(s.Back_Default);
                if (!string.IsNullOrEmpty(s.Front_Shiny)) images.Add(s.Front_Shiny);
                if (!string.IsNullOrEmpty(s.Back_Shiny)) images.Add(s.Back_Shiny);
                if (s.Sprites != null) Collect(s.Sprites);
            }
            Collect(pokemon.Sprites);
            pokemon.Images = images.Distinct().ToList();
        }

        // Extrae nombres de tipos y habilidades desde las propiedades parseadas de PokeAPI
        private void PopulateTypesAndAbilities(Pokemon pokemon)
        {
            // Tipos
            if (pokemon.types != null && pokemon.types.Count > 0)
            {
                pokemon.TypeNames = pokemon.types
                    .OrderBy(t => t.slot)
                    .Where(t => t.type != null)
                    .Select(t => t.type.name)
                    .ToList();
            }

            // Habilidades
            if (pokemon.abilities != null && pokemon.abilities.Count > 0)
            {
                pokemon.AbilityNames = pokemon.abilities
                    .Where(a => a.ability != null)
                    .Select(a => a.ability.name)
                    .ToList();
            }
        }
    }
}
