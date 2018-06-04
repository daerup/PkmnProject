using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public pokemon Charizard = new pokemon(Types.Fire, nameof(Charizard));
        public pokemon Blaziken = new pokemon(Types.Fire, nameof(Blaziken));
        public pokemon Infernape = new pokemon(Types.Fire, nameof(Infernape));
        public pokemon Blastoise = new pokemon(Types.Water, nameof(Blastoise));
        public pokemon Feraligatr = new pokemon(Types.Water, nameof(Feraligatr));
        public pokemon Swampert = new pokemon(Types.Water, nameof(Swampert));
        public pokemon Sceptile = new pokemon(Types.Plant, nameof(Sceptile));
        public pokemon Torterra = new pokemon(Types.Plant, nameof(Torterra));
        public pokemon Venusaur = new pokemon(Types.Plant, nameof(Venusaur));

        public pokemon Pinsir = new pokemon(Types.Plant, nameof(Pinsir));
        public pokemon corsola = new pokemon(Types.Water, nameof(corsola));
        public pokemon Groudon = new pokemon(Types.Fire, nameof(Groudon));

        private double _playerDamage;
        private double _enemyDamage;
        
        public MainWindow()
        {
            InitializeComponent();
            pokemon playerPokemon = Pinsir;
            Types weakness = playerPokemon.GetWeakness();
        }

        private void _decreasePlayerHP()
        {
            double newHP = PlayerHp.Value - _playerDamage;
            while (PlayerHp.Value != newHP)
            {
                //playerHP.Value -= 0.001;
            }
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

            if (PlayerHp.SmoothValue != PlayerHp.Value)
            {
                if (PlayerHp.Tag != $@"ShouldBlink")
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
            if (EnemyHp.SmoothValue != EnemyHp.Value)
            {
                if (EnemyHp.Tag != $@"ShouldBlink")
                {
                    EnemyHp.Tag = "ShouldBlink";
                }
            }
            else
            {
                EnemyHp.Tag = "ShouldNotBlink";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EnemyHp.SmoothValue = 100; 
        }
    }
}
