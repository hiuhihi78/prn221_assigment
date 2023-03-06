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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_Project.ViewModels;
using Xceed.Wpf.Toolkit;

namespace WPF_Project.Views
{
    /// <summary>
    /// Interaction logic for Import.xaml
    /// </summary>
    public partial class Import : Page
    {
        public Import()
        {
            InitializeComponent();
            DataContext = new ImportViewModel();
        }

        private void DoubleUpDown_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            double val;
            bool isDouble = double.TryParse(e.Text, out val);
            e.Handled = !isDouble;
        }
    }
}
