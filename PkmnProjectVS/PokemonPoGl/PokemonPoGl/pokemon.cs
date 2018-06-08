using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;
using Newtonsoft.Json;

namespace PokemonPoGl
{
    public enum Types
    {
        Fire,
        Water,
        Plant,
        Normal
    }

    public class Pokemon
    {
        private static readonly Attack Precipiceblades = new Attack(nameof(Precipiceblades), Types.Fire, 600);

        public string Name { get; set; }
        public bool Beaten { get; set; }

        public Types Type { get; set; }
        public ImageSource FrontPath;
        public ImageSource BackPath;

        public Thickness FrontMargin { get; set; }
        public Thickness BackMargin { get; set; }
        private Random _random = new Random();


        [JsonIgnore]
        public Attack StabAttack { get; set; }
        [JsonIgnore]
        public Attack NormalAttack { get; set; }

        [SuppressMessage("ReSharper", "ArrangeThisQualifier")]

        public Pokemon()
        {
        }
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
                StabAttack = Precipiceblades;
            }
            else
            {
                StabAttack = Precipiceblades;
            }
        }

        public Types GetWeakness()
        {
            switch (Type)
            {
                case Types.Fire: return Types.Water;
                case Types.Water: return Types.Plant;
                case Types.Plant: return Types.Fire;
                default: return Types.Normal;
            }
        }
    }
}