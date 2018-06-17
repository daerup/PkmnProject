using System;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für HelpWindowView.xaml
    /// </summary>
    public partial class HelpWindowView
    {
        public HelpWindowView()
        {
            this.InitializeComponent();
        }

        private void HelpWindowView_OnClosed(object sender, EventArgs e)
        {
            GameSettings.HelpIsOpen = false;
        }
    }
}
