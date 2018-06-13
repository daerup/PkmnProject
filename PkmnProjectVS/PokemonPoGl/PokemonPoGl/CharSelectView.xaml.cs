using System.Collections.Generic;
using System.Media;
using System.Windows;
using WpfAnimatedGif;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für CharSelectView.xaml
    /// </summary>
    public partial class CharSelectView
    {
        private List<Pokemon> allPokemon = JsonSerialization.ReadFromJsonFile<List<Pokemon>>(@"../../res/json/Pokemon.json");
        public Pokemon Groudon = GameSettings.Groudon;
        SoundPlayer titleMusic = new SoundPlayer(@"../../res/music/titleMusic.wav");
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
            InitializeComponent();
            AddGroudon();
            this.titleMusic.PlayLooping();

            this.Index = 0;
            ImageBehavior.SetAnimatedSource(this.Pokemon, this.allPokemon[this.Index].FrontPath);
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
            UpdateImage();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            this.Index++;
            UpdateImage();
        }

        private void UpdateImage()
        {
            ImageBehavior.SetAnimatedSource(this.Pokemon, this.allPokemon[this.index].FrontPath);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            this.titleMusic.Stop();

            if (this.HardMode.IsChecked == true)
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
            Close();
        }
    }
}
