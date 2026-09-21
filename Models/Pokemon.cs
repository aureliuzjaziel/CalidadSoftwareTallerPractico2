namespace TallerPractico.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public decimal Order { get; set; }
        public PokemonSprites Sprites { get; set; }
        // Lista con todas las URLs de imágenes/sprites del Pokémon (se rellenará desde el servicio)
        public List<string> Images { get; set; } = new List<string>();
    }
}
