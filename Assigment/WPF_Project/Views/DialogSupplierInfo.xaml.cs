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

namespace WPF_Project.Views
{
    /// <summary>
    /// Interaction logic for DialogSupplierInfo.xaml
    /// </summary>
    public partial class DialogSupplierInfo : Window
    {
        public DialogSupplierInfo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            double val;
            bool isDouble = double.TryParse(e.Text, out val);
            e.Handled = !isDouble;
        }
    }
}
