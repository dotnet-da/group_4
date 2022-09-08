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
            DataContext = new PlayerViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new PlayerViewModel();
            DataContext = viewModel;
        }

        private void btnType_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new ToolTypeViewModel();
            DataContext = viewModel;
        }
    }
}
