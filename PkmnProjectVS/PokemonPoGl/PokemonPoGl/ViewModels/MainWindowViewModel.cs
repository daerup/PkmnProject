using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonPoGl.MVVM;
using PokemonPoGl.ViewModels;
using PokemonPoGl.Views;

namespace PokemonPoGl
{
    class MainWindowViewModel : ViewModelBase
    {
        public GameModeViewModel GameModeViewModel { get; set; }
        public HelpViewModel HelpViewModel { get; set; }
        public PokemonBeatenCounterViewModel PokemonBeatenCounterViewModel { get; set; }
        public MainWindowViewModel()
        {
            this.GameModeViewModel = new GameModeViewModel();
            this.HelpViewModel = new HelpViewModel();
            this.PokemonBeatenCounterViewModel = new PokemonBeatenCounterViewModel();
        }
    }
}
