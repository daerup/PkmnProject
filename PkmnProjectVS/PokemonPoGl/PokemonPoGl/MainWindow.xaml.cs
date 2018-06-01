using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializePokemon();
            InitializeAttacks();
        }
    }
    void InitializePokemon()
    {
        pokemon Charizard = new pokemon(types.fire);
        pokemon Blaziken = new pokemon(types.fire);
        pokemon Infernape = new pokemon(types.fire);
        pokemon Blastoise = new pokemon(types.water);
        pokemon Feraligatr = new pokemon(types.water);
        pokemon Swampert = new pokemon(types.water);
        pokemon Sceptile = new pokemon(types.plant);
        pokemon Torterra = new pokemon(types.plant);
        pokemon Venusaur = new pokemon(types.plant);

        pokemon Pinsir = new pokemon(types.plant);
        pokemon corsola = new pokemon(types.water);
        pokemon Groudon = new pokemon(types.fire);

    }
}
