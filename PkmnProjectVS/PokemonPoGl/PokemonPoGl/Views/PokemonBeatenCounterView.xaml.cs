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

namespace PokemonPoGl.Views
{
    /// <summary>
    /// Interaktionslogik für PokemonBeatenCounter.xaml
    /// </summary>
    public partial class PokemonBeatenCounterView : UserControl
    {
        private int _beatenPokemon;
        public int BeatenPokemon{
            get
            {
                return _beatenPokemon;
            }
            set
            {
                this._beatenPokemon = value;
                this.UpdateBeatenPokemon(_beatenPokemon);
            }
        }

        public PokemonBeatenCounterView()
        {
            InitializeComponent();
        }
        public void UpdateBeatenPokemon(int Counter)
        {
            PokemonBeatenCounter.Content = "Beaten Pokemon: "+ Counter.ToString();
        }
    }
}
