namespace PokemonPoGl
{
    public enum Types
    {
        Fire,
        Water,
        Plant
    }
    public class pokemon
    {
        public string Name { get; set; }
        public Types Type { get; set; }
        attack _stabAttack = new attack();
        attack _normalAttack = new attack();
        public int Hp
        {
            get => Hp;
            private set
            {
                if (Hp > 1000)
                {
                    Hp = 1000;
                }
                else if (Hp < 0)
                {
                    Hp = 0;
                }
            }
        }


       

        public pokemon(Types type, string name)
        {
            Type = type;
            Name = name;
        }

        public Types GetWeakness()
        {
            switch (Type)
            {
                case Types.Water: return Types.Plant;
                case Types.Plant: return Types.Fire;
                default: return Types.Fire;
            }     
        }

    }
}
