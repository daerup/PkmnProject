using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Threading;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public pokemon Charizard = new pokemon(types.fire);
        public pokemon Blaziken = new pokemon(types.fire);
        public pokemon Infernape = new pokemon(types.fire);
        public pokemon Blastoise = new pokemon(types.water);
        public pokemon Feraligatr = new pokemon(types.water);
        public pokemon Swampert = new pokemon(types.water);
        public pokemon Sceptile = new pokemon(types.plant);
        public pokemon Torterra = new pokemon(types.plant);
        public pokemon Venusaur = new pokemon(types.plant);

        public pokemon Pinsir = new pokemon(types.plant);
        public pokemon corsola = new pokemon(types.water);
        public pokemon Groudon = new pokemon(types.fire);

        
        public MainWindow()
        {
            InitializeComponent();
            types weakness = Pinsir.GetWeakness();

            //blink();

        }
        public void blink()
        {
            for (int i = 0; i < 10; i++)
            {
                enemyPokemon.Visibility = System.Windows.Visibility.Hidden;
                Thread.Sleep(500);
                enemyPokemon.Visibility = System.Windows.Visibility.Visible; 
            }
        }

        private async void enemyPokemon_MouseEnter(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {

                enemyPokemon.Visibility = System.Windows.Visibility.Hidden;
                await PutTaskDelay();
                enemyPokemon.Visibility = System.Windows.Visibility.Visible;

            }
        }
        async Task PutTaskDelay()
        {
            await Task.Delay(200);
        }
    }
}
