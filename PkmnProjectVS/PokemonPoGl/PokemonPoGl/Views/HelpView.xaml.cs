using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PokemonPoGl
{
    /// <summary>
    /// Interaction logic for HelpView.xaml
    /// </summary>
    public partial class HelpView
    {
        public HelpView()
        {
            this.InitializeComponent();
        }

        private void Help_OnMouseEnter(object sender, MouseEventArgs e)
        {
            DropShadowEffect dropShadowEffect = new DropShadowEffect
            {
                Opacity = 1,
                ShadowDepth = 5,
                BlurRadius = 1,
                Color = Colors.Black
            };

            this.Help.Effect = dropShadowEffect;
        }

        private void Help_OnMouseLeave(object sender, MouseEventArgs e)
        {
            this.Help.Effect = null;
        }
    }
}
