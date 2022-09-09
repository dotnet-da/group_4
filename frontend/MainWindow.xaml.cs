using frontend.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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

        private void btnCollection_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = new CollectionViewModel();
            DataContext = viewModel;
        }

        private void EntryViewMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = new EntryListViewModel();
            DataContext = viewModel;
        }
        
        private void TopBar_Down(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Maximise_OnClick(object sender, RoutedEventArgs e)
        {
            if (Application.Current.MainWindow!.WindowState != WindowState.Maximized)
            {
                Application.Current.MainWindow!.WindowState = WindowState.Maximized;
            }
            else
            {
                Application.Current.MainWindow!.WindowState = WindowState.Normal;
            }
        }

        private void Minimise_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow!.WindowState = WindowState.Minimized;
        }
        
    }
}
