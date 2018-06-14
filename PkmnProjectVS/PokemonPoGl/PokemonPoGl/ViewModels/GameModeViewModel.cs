using System.Windows.Media;

namespace PokemonPoGl
{
    internal class GameModeViewModel : ViewModelBase
    {
        public string GameMode { get; set; }
        public SolidColorBrush GameModeContentColor { get; set; }
        public GameModeViewModel()
        {
            this.SetGameModeContent();
        }

        private void SetGameModeContent()
        {
            if (GameSettings.Hardmode)
            {
                this.GameMode = "Hard-Mode";
                this.GameModeContentColor = Brushes.OrangeRed;
            }
            else
            {
                this.GameMode = "Normal-Mode";
                this.GameModeContentColor = Brushes.ForestGreen;
            }
        }
    }
}