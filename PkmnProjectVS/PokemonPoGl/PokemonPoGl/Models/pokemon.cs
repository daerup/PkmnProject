using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;
using Newtonsoft.Json;

namespace PokemonPoGl
{
    public class Pokemon
    {
        private static readonly Attack Precipiceblades = new Attack(nameof(Precipiceblades), Types.Fire, 66600);

        public string Name { get; set; }
        public bool Beaten { get; set; }

        public Types Type { get; set; }
        public ImageSource FrontPath;
        public ImageSource BackPath;

        public Thickness FrontMargin { get; set; }
        public Thickness BackMargin { get; set; }


        [JsonIgnore]
        public Attack StabAttack { get; set; }
        [JsonIgnore]
        public Attack NormalAttack { get; set; }

        [SuppressMessage("ReSharper", "ArrangeThisQualifier")]

        public Pokemon(Types type, string name, Thickness backSideMargin, Thickness frontSideMargin)
        {
            this.Name = name;
            string backSidePath = $@"pack://application:,,,/res/sprites/{name}/back.gif";
            string frontSidePath = $@"pack://application:,,,/res/sprites/{name}/front.gif";
            this.Type = type;
            
            this.FrontMargin = frontSideMargin;
            this.BackMargin = backSideMargin;
            this.Beaten = false;

            this.FrontPath = new ImageSourceConverter().ConvertFromString(frontSidePath) as ImageSource;
            this.BackPath = new ImageSourceConverter().ConvertFromString(backSidePath) as ImageSource;

            if (this.Name == "Groudon")
            {
                this.StabAttack = Precipiceblades;
            }
            else
            {
                this.StabAttack = Precipiceblades;
            }
        }

        public Types GetWeakness()
        {
            switch (this.Type)
            {
                case Types.Fire: return Types.Water;
                case Types.Water: return Types.Plant;
                case Types.Plant: return Types.Fire;
                default: return Types.Normal;
            }
        }
    }
}