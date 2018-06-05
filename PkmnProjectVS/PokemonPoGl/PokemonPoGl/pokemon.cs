using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Forms.VisualStyles;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PokemonPoGl
{
    public enum Types
    {
        Fire,
        Water,
        Plant
    }
    public class Pokemon
    {
        public string Name { get; set; }


        public Types Type { get; set; }
        public BitmapImage FrontPath = new BitmapImage();
        public BitmapImage BackPath = new BitmapImage();

        public Thickness FrontMargin { get; set; }
        public Thickness BackMargin { get; set; }

        // ReSharper disable once UnusedMember.Local
        attack _stabAttack = new attack();
        // ReSharper disable once UnusedMember.Local
        attack _normalAttack = new attack();
        public int Hp
        {
            get
            {
                return Hp;
            }

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


        [SuppressMessage("ReSharper", "ArrangeThisQualifier")]
        public Pokemon(Types type, string name, Thickness back, Thickness front)
        {
            this.Type = type;
            this.Name = name;
            this.FrontMargin = front;
            this.BackMargin = back;
            
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
