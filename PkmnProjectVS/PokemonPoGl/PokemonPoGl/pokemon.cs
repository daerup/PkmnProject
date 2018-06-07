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

        public static readonly List<Attack> NormalAttacks = new List<Attack>();
        public static readonly List<Attack> FireAttacks = new List<Attack>();
        public static readonly List<Attack> WaterAttacks = new List<Attack>();
        public static readonly List<Attack> PlantAttacks = new List<Attack>();
        private static Random _random = new Random();
        private static bool _hasRun = false;

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

            CreateAttacks();

            if (this.Name != "Groudon")
            {
                int rStab;
                switch (type)
                {
                    case Types.Fire:
                        rStab = _random.Next(0, FireAttacks.Count - 1);
                        StabAttack = FireAttacks[rStab];
                        FireAttacks.RemoveAt(rStab);
                        break;
                    case Types.Water:
                        rStab = _random.Next(0, WaterAttacks.Count - 1);
                        StabAttack = WaterAttacks[rStab];
                        WaterAttacks.RemoveAt(rStab);
                        break;
                    case Types.Plant:
                        rStab = _random.Next(0, PlantAttacks.Count - 1);
                        StabAttack = PlantAttacks[rStab];
                        PlantAttacks.RemoveAt(rStab);
                        break;
                }
            }
            else
            {
                StabAttack = Precipiceblades;
            }

            int rNormal = _random.Next(0, NormalAttacks.Count -1);

            NormalAttack = NormalAttacks[rNormal];
            NormalAttacks.RemoveAt(rNormal);
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

        private static void CreateAttacks()
        {
            if (!_hasRun)
            {
                // ReSharper disable InconsistentNaming
                //normal Attack
                Attack Extreamspeed = new Attack(nameof(Extreamspeed), Types.Normal, 200);
                Attack Gigaimpact = new Attack(nameof(Gigaimpact), Types.Normal, 240);
                Attack Guillotine = new Attack(nameof(Guillotine), Types.Normal, 600);
                Attack Headcharge = new Attack(nameof(Headcharge), Types.Normal, 450);
                Attack Boomburst = new Attack(nameof(Boomburst), Types.Normal, 250);
                Attack Hyperbeam = new Attack(nameof(Hyperbeam), Types.Normal, 550);
                Attack Doublehit = new Attack(nameof(Doublehit), Types.Normal, 220);
                Attack Explosion = new Attack(nameof(Explosion), Types.Normal, 400);
                Attack Headbutt = new Attack(nameof(Headbutt), Types.Normal, 300);
                Attack Judgment = new Attack(nameof(Judgment), Types.Normal, 480);
                Attack Megakick = new Attack(nameof(Megakick), Types.Normal, 250);
                Attack Eggbomb = new Attack(nameof(Eggbomb), Types.Normal, 250);
                Attack Thrash = new Attack(nameof(Thrash), Types.Normal, 450);
                Attack Takle = new Attack(nameof(Takle), Types.Normal, 250);
                Attack Cut = new Attack(nameof(Cut), Types.Normal, 250);


                //fire Attack
                Attack Flamethrower = new Attack(nameof(Flamethrower), Types.Fire, 400);
                Attack Searingshot = new Attack(nameof(Searingshot), Types.Fire, 300);
                Attack Incinerate = new Attack(nameof(Incinerate), Types.Fire, 280);
                Attack Blueflare = new Attack(nameof(Blueflare), Types.Fire, 450);
                Attack Lavaplume = new Attack(nameof(Lavaplume), Types.Fire, 250);
                Attack Blastburn = new Attack(nameof(Blastburn), Types.Fire, 500);
                Attack Vcreate = new Attack(nameof(Vcreate), Types.Fire, 500);
                Attack Inferno = new Attack(nameof(Inferno), Types.Fire, 320);
                Attack Ember = new Attack(nameof(Ember), Types.Fire, 250);


                //water Attack
                Attack Watershuriken = new Attack(nameof(Watershuriken), Types.Water, 400);
                Attack Hydrocannon = new Attack(nameof(Hydrocannon), Types.Water, 500);
                Attack Waterpledge = new Attack(nameof(Waterpledge), Types.Water, 350);
                Attack Waterspout = new Attack(nameof(Waterspout), Types.Water, 400);
                Attack Bubblebeam = new Attack(nameof(Bubblebeam), Types.Water, 350);
                Attack Hydropump = new Attack(nameof(Hydropump), Types.Water, 550);
                Attack Waterfall = new Attack(nameof(Waterfall), Types.Water, 380);
                Attack Watergun = new Attack(nameof(Watergun), Types.Water, 310);
                Attack Aquatail = new Attack(nameof(Aquatail), Types.Water, 330);

                //plant Attack
                Attack Frenzyplant = new Attack(nameof(Frenzyplant), Types.Plant, 500);
                Attack Solarblade = new Attack(nameof(Solarblade), Types.Plant, 250);
                Attack Woodhammer = new Attack(nameof(Woodhammer), Types.Plant, 350);
                Attack Petaldance = new Attack(nameof(Petaldance), Types.Plant, 200);
                Attack Leafstorm = new Attack(nameof(Leafstorm), Types.Plant, 400);
                Attack Powerwhip = new Attack(nameof(Powerwhip), Types.Plant, 400);
                Attack Seedflare = new Attack(nameof(Seedflare), Types.Plant, 350);
                Attack Solarbeam = new Attack(nameof(Solarbeam), Types.Plant, 500);
                Attack Synthesis = new Attack(nameof(Synthesis), Types.Plant, 400);


                //add to normal list
                NormalAttacks.Add(Cut);
                NormalAttacks.Add(Takle);
                NormalAttacks.Add(Megakick);
                NormalAttacks.Add(Judgment);
                NormalAttacks.Add(Hyperbeam);
                NormalAttacks.Add(Explosion);
                NormalAttacks.Add(Boomburst);
                NormalAttacks.Add(Gigaimpact);
                NormalAttacks.Add(Extreamspeed);
                NormalAttacks.Add(Doublehit);
                NormalAttacks.Add(Eggbomb);
                NormalAttacks.Add(Headcharge);
                NormalAttacks.Add(Headbutt);
                NormalAttacks.Add(Guillotine);
                NormalAttacks.Add(Thrash);

                //add to fire list
                FireAttacks.Add(Ember);
                FireAttacks.Add(Vcreate);
                FireAttacks.Add(Inferno);
                FireAttacks.Add(Blueflare);
                FireAttacks.Add(Lavaplume);
                FireAttacks.Add(Blastburn);
                FireAttacks.Add(Incinerate);
                FireAttacks.Add(Searingshot);
                FireAttacks.Add(Flamethrower);

                //add to water list
                WaterAttacks.Add(Watergun);
                WaterAttacks.Add(Aquatail);
                WaterAttacks.Add(Waterfall);
                WaterAttacks.Add(Hydropump);
                WaterAttacks.Add(Waterspout);
                WaterAttacks.Add(Bubblebeam);
                WaterAttacks.Add(Waterpledge);
                WaterAttacks.Add(Hydrocannon);
                WaterAttacks.Add(Watershuriken);

                //add to plant list
                PlantAttacks.Add(Leafstorm);
                PlantAttacks.Add(Powerwhip);
                PlantAttacks.Add(Seedflare);
                PlantAttacks.Add(Solarbeam);
                PlantAttacks.Add(Synthesis);
                PlantAttacks.Add(Petaldance);
                PlantAttacks.Add(Woodhammer);
                PlantAttacks.Add(Solarblade);
                PlantAttacks.Add(Frenzyplant);


                _hasRun = true;
                // ReSharper restore InconsistentNaming 
            }
        }
    }
}