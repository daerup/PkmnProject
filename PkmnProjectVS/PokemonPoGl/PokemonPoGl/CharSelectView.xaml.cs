using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Input;
using WpfAnimatedGif;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für CharSelectView.xaml
    /// </summary>
    public partial class CharSelectView
    {
        private readonly List<Pokemon> allPokemon = JsonSerialization.ReadFromJsonFile<List<Pokemon>>(@"../../res/json/Pokemon.json");
        public Pokemon Groudon = GameSettings.Groudon;
        readonly SoundPlayer titleMusic = new SoundPlayer(@"../../res/music/titleMusic.wav");
        private int index;

        public int Index
        {
            get => this.index;

            set
            {
                if (value < 0)
                    this.index = this.allPokemon.Count -1;

                else if (value > this.allPokemon.Count - 1)
                    this.index = 0;

                else
                    this.index = value;
            }
        }
        public CharSelectView()
        {
            this.InitializeComponent();
            this.AddGroudon();
            this.titleMusic.PlayLooping();

            this.Index = 0;

            this.UpdateName();
            this.UpdateImage();
        }

        private void AddGroudon()
        {
            bool unlocked = JsonSerialization.ReadFromJsonFile<bool>(@"../../res/json/unlocked.json");
            if (unlocked)
            {
                this.allPokemon.Add(this.Groudon);
            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Index--;
            this.UpdateName();
            this.UpdateImage();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this.Index++;
            this.UpdateName();
            this.UpdateImage();
        }

        private void UpdateImage()
        {
            ImageBehavior.SetAnimatedSource(this.Pokemon, this.allPokemon[this.index].FrontPath);
        }

        private void UpdateName()
        {
            this.PokemonName.Content = this.allPokemon[this.index].Name;
        }
        private void KeyPressed(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                this.Next_Click(null, null);
            }
            else if(e.Key == Key.Left)
            {
                this.Back_Click(null, null);
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.titleMusic.Stop();

            if (this.HardModeControl.IsChecked == true)
            {
                GameSettings.Hardmode = true;
            }
            else
            {
                GameSettings.Hardmode = false;
            }

            GameSettings.ChoosenPokemon = this.allPokemon[this.index].Name;
            MainWindowView mainWindowView = new MainWindowView(){DataContext = new MainWindowViewModel()};
            mainWindowView.Show();
            this.Close();
        }
    }
}
