using Practice.Common.Interfaces;

using Practice.ViewModel;

using System.Windows;

namespace Practice.GUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IView
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();

            ViewModel.View = this;
        }
        public IViewModel ViewModel => DataContext as IViewModel;
    }
}
