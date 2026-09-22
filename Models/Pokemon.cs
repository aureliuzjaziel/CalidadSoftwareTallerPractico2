namespace TallerPractico.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Height { get; set; }
        public string Weight { get; set; }
        public decimal Order { get; set; }
        public PokemonSprites Sprites { get; set; 
        public List<string> Images { get; set; } = new List<string>();
        // Tipos y habilidades
        public List<PokemonType> types { get; set; } = new List<PokemonType>();
        public List<PokemonAbility> abilities { get; set; } = new List<PokemonAbility>();
        public List<string> TypeNames { get; set; } = new List<string>();
        public List<string> AbilityNames { get; set; } = new List<string>();
    }
}
