namespace PokemonPoGl
{
    class MainWindowViewModel : ViewModelBase
    {
        public GameModeViewModel GameModeViewModel { get; set; }
        public HelpViewModel HelpViewModel { get; set; }
        public MainWindowViewModel()
        {
            this.GameModeViewModel = new GameModeViewModel();
            this.HelpViewModel = new HelpViewModel();
        }
    }
}
