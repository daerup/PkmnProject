namespace PokemonPoGl
{
    public class Attack
    {
        public string Name { get; set; }
        public Types Type { get; set; }

        public uint Strength { get; set; }

        public Attack(string name, Types type, uint strength)
        {
            Name = name;
            Type = type;
            Strength = strength;
        }
    }
}