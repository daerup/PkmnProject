using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using PokemonPoGl;
using WpfAnimatedGif;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaktionslogik für CharSelect.xaml
    /// </summary>
    public partial class CharSelect : Window
    {
        private List<Pokemon> _allPokemon = JsonSerialization.ReadFromJsonFile<List<Pokemon>>(@"../../res/json/pokemon.json");
        public Pokemon Groudon = new Pokemon(Types.Fire, nameof(Groudon), new Thickness(-39, -106, 426, -233), new Thickness(485, 10, 17, 361));
        SoundPlayer titleMusic = new SoundPlayer(@"../../res/music/titleMusic.wav");
        private int index;

        public int Index
        {
            get => index;

            set
            {
                if (value < 0)
                    index = _allPokemon.Count -1;

                else if (value > _allPokemon.Count - 1)
                    index = 0;

                else index = value;
            }
        }
        public CharSelect()
        {
            InitializeComponent();
            addGroudon();
            titleMusic.PlayLooping();


            Index = 0;
            ImageBehavior.SetAnimatedSource(Pokemon, _allPokemon[Index].FrontPath);
        }

        private void addGroudon()
        {
            bool unlocked = JsonSerialization.ReadFromJsonFile<bool>(@"../../res/json/unlocked.json");
            if (unlocked)
            {
                _allPokemon.Add(Groudon);
            }
        }


        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Index--;
            UpdateImage();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            Index++;
            UpdateImage();
        }

        private void UpdateImage()
        {
            ImageBehavior.SetAnimatedSource(Pokemon, _allPokemon[index].FrontPath);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            bool _Hardmode;
            titleMusic.Stop();

            if (HardMode.IsChecked == true)
            {
                _Hardmode = true;
            }
            else
            {
                _Hardmode = false;
            }

            MainWindow battleWindow = new MainWindow(Groudon, _allPokemon[index].Name, _Hardmode);
            if (HardMode.IsChecked == true)
            {
                battleWindow._Hardmode = true;
            }
            battleWindow.Show();
            this.Close();
        }
    }
}
