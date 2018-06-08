using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using smoothBar;
using WpfAnimatedGif;
using System.Windows.Media.Animation;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private List<Pokemon> _allPokemon = JsonSerialization.ReadFromJsonFile<List<Pokemon>>(@"../../res/json/pokemon.json");

        private List<Attack> _normalAttacks = JsonSerialization.ReadFromJsonFile<List<Attack>>(@"../../res/json/normal.json");

        private List<Attack> _fireAttacks = JsonSerialization.ReadFromJsonFile<List<Attack>>(@"../../res/json/fire.json");

        private List<Attack> _waterAttacks = JsonSerialization.ReadFromJsonFile<List<Attack>>(@"../../res/json/water.json");

        private List<Attack> _plantAttacks = JsonSerialization.ReadFromJsonFile<List<Attack>>(@"../../res/json/plant.json");

        public Pokemon Groudon = new Pokemon(Types.Fire, nameof(Groudon), new Thickness(-39, -106, 426, -233), new Thickness(485, 10, 17, 361));

        public static bool _Hardmode;
        public static bool _Dodged;
        public Pokemon PlayerPokemon;
        public Pokemon EnemyPokemon;
        private Brush _color;
        private string _effectiveness;

        private readonly Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            AssignAttacks();
            _Hardmode = false;
            PlayerPokemon = _allPokemon.Find(x => x.Name == "Pinsir");
            PrepareUi();
            DelcareEnemyPokemon();
            ShowPokemon();
        }

        private void AssignAttacks()
        {
            int r;
            foreach (Pokemon pokemon in _allPokemon)
            {
                switch (pokemon.Type)
                {
                    case Types.Fire:
                        r = _random.Next(0, _fireAttacks.Count - 1);
                        pokemon.StabAttack = _fireAttacks[r];
                        _fireAttacks.RemoveAt(r);
                        break;
                    case Types.Water:
                        r = _random.Next(0, _waterAttacks.Count - 1);
                        pokemon.StabAttack = _waterAttacks[r];
                        _waterAttacks.RemoveAt(r);
                        break;
                    case Types.Plant:
                        r = _random.Next(0, _plantAttacks.Count - 1);
                        pokemon.StabAttack = _plantAttacks[r];
                        _plantAttacks.RemoveAt(r);
                        break;
                }

                r = _random.Next(0, _normalAttacks.Count - 1);
                pokemon.NormalAttack = _normalAttacks[r];
                _normalAttacks.RemoveAt(r);
            }

            r = _random.Next(0, _normalAttacks.Count - 1);
            Groudon.NormalAttack = _normalAttacks[r];
            _normalAttacks.RemoveAt(r);
        }

        private void PrepareUi()
        {
            switch (PlayerPokemon.Type)
            {
                case Types.Fire:
                    _color = Brushes.OrangeRed;
                    break;
                case Types.Water:
                    _color = Brushes.CornflowerBlue;
                    break;
                case Types.Plant:
                    _color = Brushes.ForestGreen;
                    break;
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

        private double CalculateDamage(Pokemon attacker, Attack attack)
        {
            Pokemon defender;
            double damage = 0;
            int r;
            bool criticalhit;
            r = _random.Next(0, 11);

            if (attacker == PlayerPokemon)
            {
                defender = EnemyPokemon;
            }
            else
            {
                defender = PlayerPokemon;
            }

            if (r == 0)
            {
                _Dodged = true;
                damage = 50;
                DodgeNarrator(defender, attack);
            }
            else
            {
                _Dodged = false;
            }
            if (!_Dodged)
            {
                if (_Hardmode && attacker == EnemyPokemon)
                {
                    r = _random.Next(0, 6);
                }
                else
                {
                    r = _random.Next(0, 11);
                }

                if (r == 0)
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
                        if (!_Hardmode)
                        {
                            if (attacker == PlayerPokemon)
                            {
                                damage = (attack.Strength * 1.75);
                            }
                            else
                            {
                                damage = (attack.Strength * 1.25);
                            }
                        }
                        else
                        {
                            damage = (attack.Strength * 1.75);
                        }

                        _effectiveness = "super effective";
                    }
                    else if (attacker.GetWeakness() == defender.Type && attack.Type != Types.Normal)
                    {
                        if (!_Hardmode)
                        {
                            if (attacker == PlayerPokemon)
                            {
                                damage = (attack.Strength / 2);
                            }
                            else
                            {
                                damage = (attack.Strength / 2.5);
                            }
                        }
                        else
                        {
                            damage = (attack.Strength / 2);
                        }

                        _effectiveness = "not so effective";
                    }
                    else
                    {
                        damage = attack.Strength;
                        _effectiveness = "effective";
                    }
                }
                else
                {
                    damage = (attack.Strength * 2);
                    _effectiveness = "a Critical Hit";
                } 
            }
            return damage;
        }

        private void TakeDamage(double damage, SmoothProgressBar hpBar)
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
            int r = _random.Next(0, _allPokemon.Count - 1);

            UpdateList();
            EnemyPokemon = _allPokemon[r];
            TxtPlayerPokemon.Text = PlayerPokemon.Name;
            TxtEnemyPokemon.Text = EnemyPokemon.Name;
        }

        private void UpdateList()
        {
            _allPokemon.RemoveAll(a => a.Beaten);
            _allPokemon.RemoveAll(a => a.Name == PlayerPokemon.Name);
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

            if (Math.Abs(PlayerHp.SmoothValue - PlayerHp.Value) > 0) //genauer als ==
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
            if (EnemyHp.Value < (EnemyHp.Maximum / 4))
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

            if (Math.Abs(EnemyHp.SmoothValue - EnemyHp.Value) > 0)
            {
                if ((string) EnemyHp.Tag != "ShouldBlink")
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
            if (_allPokemon.Count == 0)
            {
                if (!Groudon.Beaten)
                {
                    _allPokemon.Add(Groudon);
                }
                else
                {
                    MessageBox.Show("Sie haben gewonnen");
                }
            }
        }

        private void EnemyAttack()
        {
            List<Attack> availableAttacks = new List<Attack>();

            availableAttacks.Add(EnemyPokemon.NormalAttack);
            availableAttacks.Add(EnemyPokemon.StabAttack);

            int r = _random.Next(0, 2);

            double damage = CalculateDamage(EnemyPokemon, availableAttacks[r]);
            TakeDamage(damage, PlayerHp);

            if (!_Dodged)
            {
                AttackNarrator(EnemyPokemon, availableAttacks[r]);
            }
            else
            {
                _Dodged = false;
            }

            availableAttacks.Clear();
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

        private void DodgeNarrator(Pokemon defender, Attack attack)
        {
            
            string statement = $"{defender.Name} has dodged {attack.Name}!";
            Narrator.Text = statement;
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
            _Dodged = false;

            double damage = CalculateDamage(PlayerPokemon, PlayerPokemon.NormalAttack);
            TakeDamage(damage, EnemyHp);
            if (!_Dodged)
            {
                AttackNarrator(PlayerPokemon, PlayerPokemon.NormalAttack); 
            }
        }

        private void Stab_Click(object sender, RoutedEventArgs e)
        {
            _Dodged = false;
            double damage = CalculateDamage(PlayerPokemon, PlayerPokemon.StabAttack);
            TakeDamage(damage, EnemyHp);
            if (!_Dodged)
            {
                AttackNarrator(PlayerPokemon, PlayerPokemon.StabAttack); 
            }
        }
    }
}