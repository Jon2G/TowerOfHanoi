using System.Windows.Controls;
namespace TowerOfHanoi
{
    /// <summary>
    /// Lógica de interacción para Disco.xaml
    /// </summary>
    public partial class Disco : UserControl
    {
        public readonly int valor;
        public Disco(int valor)
        {
            InitializeComponent();
            this.valor = valor;
            Width = valor * 300;
            Background = Colors.NextColor();
            TxtValor.Text = valor.ToString();
            this.ToolTip = "Disco #" + valor;
        }
        public Disco()
        {
            InitializeComponent();
        }
        public void Tamanio(ref double WSizeFactor, double Height)
        {
            double w = (WSizeFactor * valor);
            if (Height <= 0 || w <= 0) { return;}
            Dispatcher.Invoke(() =>
            {
                this.Width = w;
                this.Height = Height;
                this.MaxHeight = Height;
            });
        }
    }

}
