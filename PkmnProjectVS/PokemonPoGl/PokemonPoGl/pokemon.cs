using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PokemonPoGl
{
    public enum types
    {
        fire,
        water,
        plant
    }
    public class pokemon
    {
        public types type { get; set; }
        public int hp
        {
            get
            {
                return hp;
            }
            set
            {
                if (hp > 1000)
                {
                    hp = 1000;
                }
                else if (hp < 0)
                {
                    hp = 0;
                }
            }
        }
        attack stabAttack = new attack();
        attack normalAttack = new attack();

       

        public pokemon(types type)
        {

            this.type = type;
        }

        public types GetWeakness()
        {
            switch (this.type)
            {
                case types.water: return types.plant;
                case types.plant: return types.fire;
                default: return types.fire;
            }     
        }

    }
}
