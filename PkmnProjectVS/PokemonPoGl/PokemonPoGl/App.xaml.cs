using System.Windows;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        private void App_OnStartUp(object sender, StartupEventArgs e)
        {
            CharSelectView charSelectView = new CharSelectView(){DataContext = new CharSelectViewModel()};
            charSelectView.Show();
        }
    }
}
