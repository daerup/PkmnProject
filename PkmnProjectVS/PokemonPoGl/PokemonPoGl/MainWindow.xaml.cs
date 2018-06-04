using System;
using System.Windows;
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
        public Pokemon Charizard = new Pokemon(Types.Fire, nameof(Charizard), new Thickness(-99,16,454,0), new Thickness(525,10,17,379));
        public Pokemon Blaziken = new Pokemon(Types.Fire, nameof(Blaziken), new Thickness(102,279,497,130), new Thickness(585,96,168,375));
        public Pokemon Infernape = new Pokemon(Types.Fire, nameof(Infernape), new Thickness(30,233,481,110), new Thickness(585,96,80,357));
        public Pokemon Blastoise = new Pokemon(Types.Water, nameof(Blastoise), new Thickness(75,204,505,10), new Thickness(592,97,135,312));
        public Pokemon Feraligatr = new Pokemon(Types.Water, nameof(Feraligatr), new Thickness(41,59,466,-26), new Thickness(526,59,120,347));
        public Pokemon Swampert = new Pokemon(Types.Water, nameof(Swampert), new Thickness(48,159,411,0), new Thickness(507,48,105,372));
        public Pokemon Sceptile = new Pokemon(Types.Plant, nameof(Sceptile), new Thickness(22,194,494,31), new Thickness(498,39,114,381));
        public Pokemon Torterra = new Pokemon(Types.Plant, nameof(Torterra), new Thickness(15,129,444,48), new Thickness(548,48,64,372));
        public Pokemon Venusaur = new Pokemon(Types.Plant, nameof(Venusaur), new Thickness(48,189,411,-12), new Thickness(530,93,82,327));
         
        public Pokemon Pinsir = new Pokemon(Types.Plant, nameof(Pinsir), new Thickness(77,10,415,-118), new Thickness(550,20,75,342));
        public Pokemon Corsola = new Pokemon(Types.Water, nameof(Corsola), new Thickness(144,296,555,-26), new Thickness(667,185,156,347));
        public Pokemon Groudon = new Pokemon(Types.Fire, nameof(Groudon), new Thickness(-39,-106,426,-233), new Thickness(485,10,17,361));

        public Pokemon PlayerPokemon;
        public Pokemon EnemyPokemon;

        public MainWindow()
        {
            InitializeComponent();
            DelcarePokemon(Charizard,Groudon);


            //Types weakness = playerPokemon.GetWeakness();
        }

        private void DelcarePokemon(Pokemon player, Pokemon enemy)
        {
            PlayerPokemon = player;
            EnemyPokemon = enemy;
            TxtPlayerPokemon.Text = PlayerPokemon.Name;
            TxtEnemyPokemon.Text = EnemyPokemon.Name;
        }

        private void ShowPokemon()
        {
            var back = $@"res/sprites/{PlayerPokemon.Name}/back.gif";
            var front = $@"res/sprites/{EnemyPokemon.Name}/front.gif";

            PlayerPokemon.BackPath.BeginInit();
            PlayerPokemon.BackPath.UriSource = new Uri(back, UriKind.Relative);
            PlayerPokemon.BackPath.EndInit();

            EnemyPokemon.FrontPath.BeginInit();
            EnemyPokemon.FrontPath.UriSource = new Uri(front, UriKind.Relative);
            EnemyPokemon.FrontPath.EndInit();

            ImageBehavior.SetAnimatedSource(ImgPlayerPokemon, PlayerPokemon.BackPath);
            ImageBehavior.SetAnimatedSource(ImgEnemyPokemon, EnemyPokemon.FrontPath);

            ImageBehavior.SetRepeatBehavior(ImgPlayerPokemon, RepeatBehavior.Forever);
            ImageBehavior.SetRepeatBehavior(ImgEnemyPokemon, RepeatBehavior.Forever);

            ImageBehavior.SetAutoStart(ImgPlayerPokemon, false);
            ImageBehavior.SetAutoStart(ImgEnemyPokemon, false);

            ImgPlayerPokemon.Margin = PlayerPokemon.BackMargin;
            ImgEnemyPokemon.Margin = EnemyPokemon.FrontMargin;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            ShowPokemon();
            TakeDamage(800, EnemyHp);
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

            if (Math.Abs(PlayerHp.SmoothValue - PlayerHp.Value) > 0)//genauer als ==
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
            if (Math.Abs(EnemyHp.SmoothValue - EnemyHp.Value) > 0) //genauer als ==
            {
                if ((string) EnemyHp.Tag != "ShouldBlink")
                {
                    EnemyHp.Tag = "ShouldBlink";
                }
            }
            else
            {
                EnemyHp.Tag = "ShouldNotBlink";
            }
        }

        private static void TakeDamage(double damage, SmoothProgressBar hpBar)
        {
            double newHp = hpBar.Value - damage;

            if (newHp < 0)
            {
                newHp = 0;
            }else if (newHp > 1000)
            {
                newHp = 1000;
            }

            hpBar.SmoothValue = newHp;
        }
    }
}
