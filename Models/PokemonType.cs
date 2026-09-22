namespace TallerPractico.Models
{
    public class PokemonType
    {
        public int slot { get; set; }
        public TypeInfo type { get; set; }
    }

    public class TypeInfo
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokemonAbility
    {
        public bool is_hidden { get; set; }
        public int slot { get; set; }
        public AbilityInfo ability { get; set; }
    }

    public class AbilityInfo
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}
