using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace TowerOfHanoi
{
    /// <summary>
    /// Lógica de interacción para Palito.xaml
    /// </summary>
    public partial class Palito : UserControl
    {
        private int i;
        private int totalDiscos;
        private double SizeFactor;
        public Palito()
        {
            InitializeComponent();
            i = 0;
        }
        public Disco Pop()
        {
            Disco fuera = null;
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
                {
                    fuera = (Disco)DiscosG.Children[i - 1];
                    DiscosG.Children.RemoveAt(i - 1);
                })).Wait();
            i--;
            return fuera;
        }
        public void Push(Disco n, int totalDiscos)
        {
            this.totalDiscos = totalDiscos;
            SizeFactor = DiscosG.ActualWidth / totalDiscos;
            Dispatcher.Invoke(() =>
            {
                n.Tamanio(ref SizeFactor, (ActualHeight - 30) / totalDiscos);
                DiscosG.Children.Add(n);
            });
            i++;
        }
        public void Push(Disco n)
        {
            Dispatcher.Invoke(() =>
            {
                DiscosG.Children.Add(n);
            });
            i++;
        }
        private void Palito_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (totalDiscos.Equals(0))
            {
                Base.Width = this.Width;
                return;
            }
            SizeFactor = e.NewSize.Width / totalDiscos;
            foreach (Disco disco in DiscosG.Children)
            {
                Dispatcher.Invoke(() => { disco.Tamanio(ref SizeFactor, (ActualHeight - 30) / totalDiscos); });
            }
            Base.Width = SizeFactor * totalDiscos;
            //this.Base.Height = (ActualHeight - 30) / totalDiscos;
        }

        internal void Reset()
        {
            Dispatcher.Invoke(() =>
            {
                DiscosG.Children.Clear();
            });
            i = 0;
            totalDiscos = 0;
            SizeFactor = 0;
        }

        public int UlitmoValor()
        {
            return ((Disco)DiscosG.Children[DiscosG.Children.Count - 1]).valor;
        }
    }
}
