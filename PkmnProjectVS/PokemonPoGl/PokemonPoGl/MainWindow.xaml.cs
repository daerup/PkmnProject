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
            double newHP = playerHP.Value - _playerDamage;
            while (playerHP.Value != newHP)
            {
                //playerHP.Value -= 0.001;
            }
        }

        private void PlayerHP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (playerHP.Value < (playerHP.Maximum / 4)) //Damit immer nach 25% geprüft wird
            {
                playerHP.Foreground = Brushes.Red;
            }
            else if (playerHP.Value < (playerHP.Maximum / 2))
            {
                playerHP.Foreground = Brushes.Orange;
            }
            else
            {
                playerHP.Foreground = Brushes.Green;
            }
        }

        private void EnemyHP_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (enemyHP.Value < (enemyHP.Maximum / 4)) //Damit immer nach 25% geprüft wird
            {
                enemyHP.Foreground = Brushes.Red;
            }
            else if (enemyHP.Value < (enemyHP.Maximum / 2))
            {
                enemyHP.Foreground = Brushes.Orange;
            }
            else
            {
                enemyHP.Foreground = Brushes.Green;
            }
            //Storyboard sb = this.FindResource("playerBlink") as Storyboard;
            //sb.Begin();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            playerHP._value = 20; 
        }
    }
}
