using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using smoothBar;
using WpfAnimatedGif;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PokemonPoGl.Annotations;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public Pokemon Charizard = new Pokemon(Types.Fire, nameof(Charizard));
        public Pokemon Blaziken = new Pokemon(Types.Fire, nameof(Blaziken));
        public Pokemon Infernape = new Pokemon(Types.Fire, nameof(Infernape));
        public Pokemon Blastoise = new Pokemon(Types.Water, nameof(Blastoise));
        public Pokemon Feraligatr = new Pokemon(Types.Water, nameof(Feraligatr));
        public Pokemon Swampert = new Pokemon(Types.Water, nameof(Swampert));
        public Pokemon Sceptile = new Pokemon(Types.Plant, nameof(Sceptile));
        public Pokemon Torterra = new Pokemon(Types.Plant, nameof(Torterra));
        public Pokemon Venusaur = new Pokemon(Types.Plant, nameof(Venusaur));
         
        public Pokemon Pinsir = new Pokemon(Types.Plant, nameof(Pinsir));
        public Pokemon Corsola = new Pokemon(Types.Water, nameof(Corsola));
        public Pokemon Groudon = new Pokemon(Types.Fire, nameof(Groudon));
        public Pokemon PlayerPokemon;
        public Pokemon EnemyPokemon;

        private string playerSource;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;


            PlayerPokemon = Corsola;
            EnemyPokemon = Groudon;
            TxtPlayerPokemon.Text= PlayerPokemon.Name;
            TxtEnemyPokemon.Text = EnemyPokemon.Name;

            ShowPokemon();



            //Types weakness = playerPokemon.GetWeakness();
        }

        private void ShowPokemon()
        {
            var front = $@"res/sprites/{EnemyPokemon.Name}/front.gif";
            var back = $@"res/sprites/{PlayerPokemon.Name}/back.gif";

            EnemyPokemon.FrontPath.BeginInit();
            EnemyPokemon.FrontPath.UriSource = new Uri(front);
            EnemyPokemon.FrontPath.EndInit();

            PlayerPokemon.BackPath.BeginInit();
            PlayerPokemon.BackPath.UriSource = new Uri(back);
            PlayerPokemon.BackPath.EndInit();

            ImageBehavior.SetAnimatedSource(ImgPlayerPokemon, PlayerPokemon.BackPath);
            ImageBehavior.SetAnimatedSource(ImgEnemyPokemon, EnemyPokemon.FrontPath);

        }

        //new System.Windows.Media.Imaging.BitmapImage(new Uri("../../images/VIBlend.png", UriKind.Relative));
        public void Button_Click(object sender, RoutedEventArgs e)
        {
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
