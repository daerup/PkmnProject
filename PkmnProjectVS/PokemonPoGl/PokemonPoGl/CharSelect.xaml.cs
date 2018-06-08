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
        SoundPlayer titleMusic = new SoundPlayer(@"../../res/music/titleMusic.wav");
        private int index;

        public int Index
        {
            get => index;

            set
            {
                if (value < 0)
                    index = 10;

                else if (value > 10)
                    index = 0;

                else index = value;
            }
        }
        public CharSelect()
        {
            InitializeComponent();

            titleMusic.PlayLooping();


            Index = 0;
            ImageBehavior.SetAnimatedSource(Pokemon, _allPokemon[Index].FrontPath);
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
            JsonSerialization.WriteToJsonFile(@"../../res/json/player.json", _allPokemon[index]);
            titleMusic.Stop();
            MainWindow battleWindow = new MainWindow();

            if (HardMode.IsChecked == true)
            {
                battleWindow._Hardmode = true;
            }
            this.Hide();
            battleWindow.Show();

        }
    }
}
