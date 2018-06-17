namespace PokemonPoGl
{
    class CharSelectViewModel : ViewModelBase
    {
        public HelpViewModel HelpViewModel { get; set; }
        public CharSelectViewModel()
        {
            GameSettings.HelpIsOpen = false;
            this.HelpViewModel = new HelpViewModel();
        }
    }
}
