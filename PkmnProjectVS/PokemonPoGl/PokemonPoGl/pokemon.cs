using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Media;

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
        public readonly List<Attack> NormalAttacks = new List<Attack>();
        public readonly List<Attack> FireAttacks = new List<Attack>();
        public readonly List<Attack> WaterAttacks = new List<Attack>();
        public readonly List<Attack> PlantAttacks = new List<Attack>();

        public string Name { get; set; }
        public bool Beaten { get; set; }

        public Types Type { get; set; }
        public ImageSource FrontPath;
        public ImageSource BackPath; 

        public Thickness FrontMargin { get; set; }
        public Thickness BackMargin { get; set; }

        public Attack StabAttack { get; set; }
        public Attack NormalAttack { get; set; }


        [SuppressMessage("ReSharper", "ArrangeThisQualifier")]
        public Pokemon(Types type, string name, Thickness backSideMargin, Thickness frontSideMargin)
        {
            string backSidePath = $@"pack://application:,,,/res/sprites/{name}/back.gif";
            string frontSidePath = $@"pack://application:,,,/res/sprites/{name}/front.gif";
            this.Type = type;
            this.Name = name;

            this.FrontMargin = frontSideMargin;
            this.BackMargin = backSideMargin;
            this.Beaten = false;

            this.FrontPath = new ImageSourceConverter().ConvertFromString(frontSidePath) as ImageSource;
            this.BackPath = new ImageSourceConverter().ConvertFromString(backSidePath) as ImageSource;

            CreateAttacks();
            Random random = new Random();
            int r = random.Next(0, 8);
            switch (type)
            {
                case Types.Fire: StabAttack = FireAttacks[r]; break;
                case Types.Water: StabAttack = WaterAttacks[r]; break;
                case Types.Plant: StabAttack = PlantAttacks[r]; break;
            }

            r = random.Next(0, 8);
            NormalAttack = NormalAttacks[r];

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
        private void CreateAttacks()
        {
            //normal Attack
            Attack Hyperbeam = new Attack(nameof(Hyperbeam), Types.Normal, 550);
            Attack Explosion = new Attack(nameof(Explosion), Types.Normal, 250);
            Attack Takle = new Attack(nameof(Takle), Types.Normal, 150);
            Attack Extreamspeed = new Attack(nameof(Extreamspeed), Types.Normal, 200);
            Attack Boomburst = new Attack(nameof(Boomburst), Types.Normal, 250);
            Attack Gigaimpact = new Attack(nameof(Gigaimpact), Types.Normal, 240);
            Attack Megakick = new Attack(nameof(Megakick), Types.Normal, 200);
            Attack Cut = new Attack(nameof(Cut), Types.Normal, 150);
            Attack Judgment = new Attack(nameof(Judgment), Types.Normal, 400);

            //fire Attack
            Attack Blueflare = new Attack(nameof(Blueflare), Types.Fire, 350);
            Attack Incinerate = new Attack(nameof(Incinerate), Types.Fire, 180);
            Attack Searingshot = new Attack(nameof(Searingshot), Types.Fire, 200);
            Attack Lavaplume = new Attack(nameof(Lavaplume), Types.Fire, 150);
            Attack Flamethrower = new Attack(nameof(Flamethrower), Types.Fire, 300);
            Attack Ember = new Attack(nameof(Ember), Types.Fire, 150);
            Attack Inferno = new Attack(nameof(Inferno), Types.Fire, 220);
            Attack Blastburn = new Attack(nameof(Blastburn), Types.Fire, 500);
            Attack Vcreate = new Attack(nameof(Vcreate), Types.Fire, 500);

            //water Attack
            Attack Hydrocannon = new Attack(nameof(Hydrocannon), Types.Water, 500);
            Attack Waterspout = new Attack(nameof(Waterspout), Types.Water, 200);
            Attack Waterfall = new Attack(nameof(Waterfall), Types.Water, 180);
            Attack Watergun = new Attack(nameof(Watergun), Types.Water, 210);
            Attack Aquatail = new Attack(nameof(Aquatail), Types.Water, 230);
            Attack Hydropump = new Attack(nameof(Hydropump), Types.Water, 450);
            Attack Waterpledge = new Attack(nameof(Waterpledge), Types.Water, 250);
            Attack Watershuriken = new Attack(nameof(Watershuriken), Types.Water, 300);
            Attack Bubblebeam = new Attack(nameof(Bubblebeam), Types.Water, 250);

            //plant Attack
            Attack Leafstorm = new Attack(nameof(Leafstorm), Types.Plant, 300);
            Attack Powerwhip = new Attack(nameof(Powerwhip), Types.Plant, 300);
            Attack Petaldance = new Attack(nameof(Petaldance), Types.Plant, 100);
            Attack Frenzyplant = new Attack(nameof(Frenzyplant), Types.Plant, 500);
            Attack Woodhammer = new Attack(nameof(Woodhammer), Types.Plant, 250);
            Attack Seedflare = new Attack(nameof(Seedflare), Types.Plant, 250);
            Attack Solarbeam = new Attack(nameof(Solarbeam), Types.Plant, 400);
            Attack Synthesis = new Attack(nameof(Synthesis), Types.Plant, 300);
            Attack Solarblade = new Attack(nameof(Solarblade), Types.Plant, 150);

            //add to normal list
            NormalAttacks.Add(Hyperbeam);
            NormalAttacks.Add(Explosion);
            NormalAttacks.Add(Takle);
            NormalAttacks.Add(Extreamspeed);
            NormalAttacks.Add(Boomburst);
            NormalAttacks.Add(Gigaimpact);
            NormalAttacks.Add(Megakick);
            NormalAttacks.Add(Cut);
            NormalAttacks.Add(Judgment);

            //add to fire list
            FireAttacks.Add(Blueflare);
            FireAttacks.Add(Incinerate);
            FireAttacks.Add(Searingshot);
            FireAttacks.Add(Lavaplume);
            FireAttacks.Add(Flamethrower);
            FireAttacks.Add(Ember);
            FireAttacks.Add(Inferno);
            FireAttacks.Add(Blastburn);
            FireAttacks.Add(Vcreate);

            //add to water list
            WaterAttacks.Add(Hydrocannon);
            WaterAttacks.Add(Waterspout);
            WaterAttacks.Add(Waterfall);
            WaterAttacks.Add(Watergun);
            WaterAttacks.Add(Aquatail);
            WaterAttacks.Add(Hydropump);
            WaterAttacks.Add(Waterpledge);
            WaterAttacks.Add(Watershuriken);
            WaterAttacks.Add(Bubblebeam);

            //add to plant list
            PlantAttacks.Add(Leafstorm);
            PlantAttacks.Add(Powerwhip);
            PlantAttacks.Add(Petaldance);
            PlantAttacks.Add(Frenzyplant);
            PlantAttacks.Add(Woodhammer);
            PlantAttacks.Add(Seedflare);
            PlantAttacks.Add(Solarbeam);
            PlantAttacks.Add(Synthesis);
            PlantAttacks.Add(Solarblade);
        }
    }
}
