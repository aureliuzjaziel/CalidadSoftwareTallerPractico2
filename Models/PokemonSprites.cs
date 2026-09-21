namespace TallerPractico.Models
{
    public class PokemonSprites
    {
        public string Front_Default { get; set; }
        public string Back_Default { get; set; }
        public string Front_Shiny { get; set; }
        public string Back_Shiny { get; set; }
        public PokemonSprites Sprites { get; set; }
    }
}
