using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace TowerOfHanoi
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int cantidad;
        private bool resolviendo = false;
        private int movimientos;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Cargar(int cantidad)
        {
            this.cantidad = cantidad;
            for (int i = cantidad; i >= 1; i--)
            {
                Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle,
                    new Action(() => { Palito1.Push(new Disco(i), cantidad); })).Wait();
                //Thread.Sleep(200);
            }
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            Cantidad cantidad = new Cantidad()
            {
                Owner = this
            };
            Cargar(cantidad.FixShowDialog());
        }

        private void MainWindow_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (resolviendo)
            {
                MessageBox.Show("No puedes cambiar el tamaño mientras se esta resolviendo!", "Mensaje informativo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                Palito1.Reset();
                Palito2.Reset();
                Palito3.Reset();
            })).Wait();
            Cantidad cantidad = new Cantidad()
            {
                Owner = this
            };
            Cargar(cantidad.FixShowDialog());
        }

        private void ButtonBase_OnClick1(object sender, RoutedEventArgs e)
        {
            if (resolviendo)
            {
                MessageBox.Show("No puedes resetear mientras se esta resolviendo!", "Mensaje informativo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            movimientos = 0;
            Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
            {
                Palito1.Reset();
                Palito2.Reset();
                Palito3.Reset();
            })).Wait();
            Cargar(cantidad);
        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            if (Palito1.DiscosG.Children.Count <= 0)
            {
                ButtonBase_OnClick1(sender, e);
            }
            if (resolviendo)
            {
                MessageBox.Show("Ya se esta resolviendo la torre", "Mensaje informativo",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            resolviendo = true;
            int n = cantidad;
            movimientos = 0;
            Resolver(n, ref Palito1, ref Palito3, ref Palito2);
            resolviendo = false;
            MessageBox.Show("Resuelto en " + movimientos + " movimientos!.", "Resuelto",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Resolver(int n, ref Palito Origen, ref Palito Destino, ref Palito Auxiliar)
        {
            if (n == 1)
            {
                Mover(n, ref Origen, ref Destino);
                return;
            }
            Resolver(n - 1, ref Origen, ref Auxiliar, ref Destino);
            Mover(n, ref Origen, ref Destino);
            Resolver(n - 1, ref Auxiliar, ref Destino, ref Origen);
        }

        private void Mover(int n, ref Palito from_rod, ref Palito to_rod)
        {
            to_rod.Push(from_rod.Pop());
            if (cantidad < 10) { Thread.Sleep(100); }
            movimientos++;
        }
    }
}
