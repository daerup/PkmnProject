using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using smoothBar;
using WpfAnimatedGif;
using System.Windows.Media.Animation;
using PokemonPoGl.Annotations;
// ReSharper disable CompareOfFloatsByEqualityOperator
// ReSharper disable SuggestVarOrType_BuiltInTypes
// ReSharper disable SuggestVarOrType_Elsewhere

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public readonly List<Pokemon> AllPokemon = new List<Pokemon>();
        public Pokemon Groudon = new Pokemon(Types.Fire, nameof(Groudon), new Thickness(-39, -106, 426, -233), new Thickness(485, 10, 17, 361));

        public Pokemon PlayerPokemon;
        public Pokemon EnemyPokemon;
        private Brush _color;
        private string _effectiveness;

        private readonly Random _random = new Random();
        public MainWindow()
        {
            InitializeComponent();
            CreateList();
            PlayerPokemon = AllPokemon.Find(x => x.Name == "Blastoise");
            PrepareUi();
            DelcareEnemyPokemon();
            ShowPokemon();
            

            //Types weakness = playerPokemon.GetWeakness();
        }

        private void PrepareUi()
        {
            switch (PlayerPokemon.Type)
            {
                case Types.Fire: _color = Brushes.OrangeRed; break;
                case Types.Water: _color = Brushes.CornflowerBlue; break;
                case Types.Plant: _color = Brushes.ForestGreen; break;
            }

            Stab.Content = PlayerPokemon.StabAttack.Name;
            Normal.Content = PlayerPokemon.NormalAttack.Name;

            Normal.Background = new SolidColorBrush(Color.FromArgb(255, 95, 95, 95));
            Stab.Background = _color;
        }
        private void UpdateEnemy()
        {
            DelcareEnemyPokemon();
            ImageBehavior.SetAnimatedSource(ImgEnemyPokemon, EnemyPokemon.FrontPath);
            ImgEnemyPokemon_OnAnimationLoaded(ImgEnemyPokemon, null);
            EnemyHp.SmoothValue = 1000;
        }

        private double CalculateDamage([NotNull] Pokemon attacker, [NotNull] Attack attack)
        {
            Pokemon defender;
            double damage;
            bool criticalhit;
            if (attacker == PlayerPokemon)
            {
                defender = EnemyPokemon;
            }
            else
            {
                defender = PlayerPokemon;
            }

            int r = _random.Next(0, 11);
            if (r == 10)
            {
                criticalhit = true;
            }
            else
            {
                criticalhit = false;
            }

            if (!criticalhit)
            {
                if (attack.Type == defender.GetWeakness())
                {
                    if (attacker == PlayerPokemon)
                    {
                        damage = (attack.Strength * 1.75);
                    }
                    else
                    {
                        damage = (attack.Strength * 1.25);
                    }
                    _effectiveness = "super effective";
                }
                else if (attacker.GetWeakness() == defender.Type && attack.Type != Types.Normal)
                {
                    if (attacker == PlayerPokemon)
                    {
                        damage = (attack.Strength * 0.5);
                    }
                    else
                    {
                        damage = (attack.Strength * 0.3);
                    }
                    _effectiveness = "not so effective";
                }
                else
                {
                    damage = attack.Strength;
                    _effectiveness = "normal effective";
                } 
            }
            else
            {
                damage = (attack.Strength * 2);
                _effectiveness = "a Critical Hit";
            }

            return damage;

        }
        private static void TakeDamage(double damage, SmoothProgressBar hpBar)
        {
            double newHp = hpBar.Value - damage;

            if (newHp < 0)
            {
                newHp = 0;
            }
            else if (newHp > 1000)
            {
                newHp = 1000;
            }

            hpBar.SmoothValue = newHp;
        }

        private void DelcareEnemyPokemon()
        {
            int r = _random.Next(0, AllPokemon.Count-1);

            UpdateList();

            EnemyPokemon = AllPokemon[r];

            TxtPlayerPokemon.Text = PlayerPokemon.Name;
            TxtEnemyPokemon.Text = EnemyPokemon.Name;
        }
        private void CreateList()
        {
            Pokemon Charizard = new Pokemon(Types.Fire, nameof(Charizard), new Thickness(-99, 16, 454, 0), new Thickness(525, 10, 17, 379));
            Pokemon Blaziken = new Pokemon(Types.Fire, nameof(Blaziken), new Thickness(102, 279, 497, 130), new Thickness(585, 96, 168, 375));
            Pokemon Infernape = new Pokemon(Types.Fire, nameof(Infernape), new Thickness(30, 233, 481, 110), new Thickness(585, 96, 80, 357));
            Pokemon Blastoise = new Pokemon(Types.Water, nameof(Blastoise), new Thickness(75, 204, 505, 10), new Thickness(592, 97, 135, 312));
            Pokemon Feraligatr = new Pokemon(Types.Water, nameof(Feraligatr), new Thickness(41, 59, 466, -26), new Thickness(526, 35, 59, 347));
            Pokemon Swampert = new Pokemon(Types.Water, nameof(Swampert), new Thickness(48, 159, 411, 0), new Thickness(558, 142, 105, 372));
            Pokemon Sceptile = new Pokemon(Types.Plant, nameof(Sceptile), new Thickness(22, 194, 494, 31), new Thickness(540, 114, 114, 381));
            Pokemon Torterra = new Pokemon(Types.Plant, nameof(Torterra), new Thickness(15, 129, 444, 48), new Thickness(546, 93, 64, 372));
            Pokemon Venusaur = new Pokemon(Types.Plant, nameof(Venusaur), new Thickness(48, 189, 411, -12), new Thickness(530, 93, 82, 327));

            Pokemon Pinsir = new Pokemon(Types.Plant, nameof(Pinsir), new Thickness(77, 10, 415, -118), new Thickness(550, 20, 75, 342));
            Pokemon Corsola = new Pokemon(Types.Water, nameof(Corsola), new Thickness(144, 296, 555, -26), new Thickness(667, 185, 156, 347));

            AllPokemon.Add(Charizard);
            AllPokemon.Add(Blastoise);
            AllPokemon.Add(Blaziken);
            AllPokemon.Add(Infernape);
            AllPokemon.Add(Feraligatr);
            AllPokemon.Add(Swampert);
            AllPokemon.Add(Sceptile);
            AllPokemon.Add(Torterra);
            AllPokemon.Add(Venusaur);

            AllPokemon.Add(Pinsir);
            AllPokemon.Add(Corsola);
        }

        private void UpdateList()
        {
            AllPokemon.RemoveAll(a => a.Beaten);
            AllPokemon.RemoveAll(a => a.Name == PlayerPokemon.Name);
            CheckIfWon();
        }

        private void ShowPokemon()
        {
            PlayerHp.SmoothValue = 1000;
            EnemyHp.SmoothValue = 1000;
            ImageBehavior.SetAnimatedSource(ImgPlayerPokemon, PlayerPokemon.BackPath);
            ImageBehavior.SetAnimatedSource(ImgEnemyPokemon, EnemyPokemon.FrontPath);
        }

        private void PlayerHP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (PlayerHp.Value < (PlayerHp.Maximum / 4)) //Damit immer nach 25% geprüft wird
            {
                PlayerHp.Foreground = Brushes.Red;
            }
            else if (PlayerHp.Value < (PlayerHp.Maximum / 2))
            {
                PlayerHp.Foreground = Brushes.Orange;
            }
            else
            {
                PlayerHp.Foreground = Brushes.Green;
            }

            if (PlayerHp.Value == PlayerHp.SmoothValue && PlayerHp.SmoothValue != PlayerHp.Maximum && PlayerHp.SmoothValue != 0)
            {
                EnableButtons();
            }
            if (PlayerHp.SmoothValue != PlayerHp.Value)
            {
                if ((string) PlayerHp.Tag != @"ShouldBlink")
                {
                    PlayerHp.Tag = "ShouldBlink";
                }
            }
            else
            {
                PlayerHp.Tag = "ShouldNotBlink";
            }

            if (PlayerHp.Value == 0 && PlayerHp.SmoothValue == 0)
            {
                MessageBox.Show("YOU DIED");
            }
        }

        private void EnemyHP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (EnemyHp.Value < (EnemyHp.Maximum / 4)) //Damit immer nach 25% geprüft wird
            {
                EnemyHp.Foreground = Brushes.Red;
            }
            else if (EnemyHp.Value < (EnemyHp.Maximum / 2))
            {
                EnemyHp.Foreground = Brushes.Orange;
            }
            else
            {
                EnemyHp.Foreground = Brushes.Green;
            }

            if (EnemyHp.Value == EnemyHp.SmoothValue && EnemyHp.SmoothValue != EnemyHp.Maximum && EnemyHp.SmoothValue != 0)
            {
                EnemyAttack();
            }
            if (EnemyHp.SmoothValue != EnemyHp.Value)
            {
                if ((string)EnemyHp.Tag != "ShouldBlink")
                {
                    EnemyHp.Tag = "ShouldBlink";
                    if (Stab != null && Normal != null)
                    {
                        DisableButtons();
                    }
                }
            }
            else
            {
                EnemyHp.Tag = "ShouldNotBlink";
                if (Stab != null && Normal != null && EnemyHp.Value == EnemyHp.Maximum)
                {
                    EnableButtons();
                }
            }

            if (EnemyHp.Value == 0)
            {
                EnemyPokemon.Beaten = true;
                DeathNarrator(EnemyPokemon);
                PlayerHp.SmoothValue = PlayerHp.Maximum;
                UpdateEnemy();
            }

        }

        private void CheckIfWon()
        {
            if (AllPokemon.Count != 0) return;
            if (!Groudon.Beaten)
            {
                AllPokemon.Add(Groudon);
            }
            else
            {
                MessageBox.Show("Sie haben gewonnen"); 
            }
        }

        private void EnemyAttack()
        {
            List<Attack> availableAttacks = new List<Attack>
            {
                EnemyPokemon.NormalAttack,
                EnemyPokemon.StabAttack
            };

            int r = _random.Next(0, 2);

            double damage = CalculateDamage(EnemyPokemon, availableAttacks[r]);
            TakeDamage(damage, PlayerHp);

            AttackNarrator(EnemyPokemon, availableAttacks[r]);
        }
        private void DisableButtons()
        {
            Stab.IsEnabled = false;
            Normal.IsEnabled = false;
            Stab.Foreground = Brushes.SlateGray;
            Normal.Foreground = Brushes.SlateGray;
        }
        public void EnableButtons()
        {
            Stab.IsEnabled = true;
            Normal.IsEnabled = true;
            Stab.Foreground = Brushes.White;
            Normal.Foreground = Brushes.White;
        }

        private void ImgPlayerPokemon_OnAnimationLoaded(object sender, RoutedEventArgs e)
        {
            ImageBehavior.SetRepeatBehavior(ImgPlayerPokemon, RepeatBehavior.Forever);
            ImageBehavior.SetAutoStart(ImgPlayerPokemon, true);
            ImgPlayerPokemon.Margin = PlayerPokemon.BackMargin;
        }
        private void ImgEnemyPokemon_OnAnimationLoaded(object sender, RoutedEventArgs e)
        {
            ImageBehavior.SetRepeatBehavior(ImgEnemyPokemon, RepeatBehavior.Forever);
            ImageBehavior.SetAutoStart(ImgEnemyPokemon, true);
            ImgEnemyPokemon.Margin = EnemyPokemon.FrontMargin;
        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            //DisableButtons();
            double damage = CalculateDamage(PlayerPokemon, PlayerPokemon.NormalAttack);
            TakeDamage(damage, EnemyHp);
            AttackNarrator(PlayerPokemon, PlayerPokemon.NormalAttack);
        }

        private void Stab_Click(object sender, RoutedEventArgs e)
        {
            //DisableButtons();
            double damage = CalculateDamage(PlayerPokemon, PlayerPokemon.StabAttack);
            TakeDamage(damage, EnemyHp);
            AttackNarrator(PlayerPokemon, PlayerPokemon.StabAttack);
        }

        private void AttackNarrator(Pokemon attacker, Attack attack)
        {
            string statement = $"{attacker.Name} used {attack.Name}...It's {_effectiveness}";
            
            Narrator.Text = statement;
        }
        private void DeathNarrator(Pokemon deadpokemon)
        {
            string statement = $"RIP, {deadpokemon.Name}. You will be missed";
            Narrator.Text = statement;
        }
    }
}