using System;
using System.Collections.Generic;
using System.Linq;
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

namespace TowerOfHanoi
{
    /// <summary>
    /// Lógica de interacción para Cantidad.xaml
    /// </summary>
    public partial class Cantidad : Window
    {
        private int c=6;
        public Cantidad()
        {
            InitializeComponent();
            TxtCantidad.Text = c.ToString();
        }

        public  int FixShowDialog()
        {
            this.ShowDialog();
            return c;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TxtCantidad.Text = new string((from c in TxtCantidad.Text
                where char.IsDigit(c) || char.IsNumber(c)
                select c).ToArray());
             c = int.Parse((TxtCantidad.Text == string.Empty ? 1.ToString() : TxtCantidad.Text));
        }

        //Incremento unitario
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            c++;
            TxtCantidad.Text = c.ToString();
        }

        //Decremento Unitario
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            c--;
            if (c <= 0) { Button_Click_2(sender, e); }
            TxtCantidad.Text = c.ToString();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
                Button_Click(sender, e);
                return;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
