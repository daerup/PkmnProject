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
        public bool beaten { get; set; }

        public Types Type { get; set; }
        public ImageSource FrontPath;
        public ImageSource BackPath; 

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
        public Pokemon(Types type, string name, Thickness backSideMargin, Thickness frontSideMargin)
        {
            string backSidePath = $@"pack://application:,,,/res/sprites/{name}/back.gif";
            string frontSidePath = $@"pack://application:,,,/res/sprites/{name}/front.gif";
            this.Type = type;
            this.Name = name;


            this.FrontMargin = frontSideMargin;
            this.BackMargin = backSideMargin;
            this.beaten = false;

            this.FrontPath = new ImageSourceConverter().ConvertFromString(frontSidePath) as ImageSource;
            this.BackPath = new ImageSourceConverter().ConvertFromString(backSidePath) as ImageSource;
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
