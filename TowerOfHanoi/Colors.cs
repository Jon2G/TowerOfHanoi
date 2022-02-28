using System.Linq;
using System.Windows.Media;
using Color = System.Drawing.Color;

namespace TowerOfHanoi
{
    internal static class Colors
    {
        private static Color[] NiceColors = new Color[]
        {
            Color.Red, Color.Yellow, Color.Blue, Color.Green, Color.Brown,
            Color.DarkGray, Color.Orange, Color.Magenta, Color.Cyan,
            Color.MediumPurple, Color.Lime
        };
        private static int index = -1;
        public static System.Windows.Media.Brush NextColor()
        {
            index++;
            int selection = index % NiceColors.Count();

            return new SolidColorBrush(
                System.Windows.Media.Color.FromArgb(
                    NiceColors[selection].A,
                    NiceColors[selection].R, 
                    NiceColors[selection].G,
                    NiceColors[selection].B));
        }
    }
}
