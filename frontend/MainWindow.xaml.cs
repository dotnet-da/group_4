using frontend.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace frontend
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new View1ViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new View1ViewModel();
        }

        private void btnView2_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new View2ViewModel();
        }
    }
}
