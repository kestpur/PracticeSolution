using Practice.Common.Interfaces;

using System.Windows.Controls;

namespace Practice.Details.GUI.Views
{
    /// <summary>
    /// Interaction logic for CharacterView.xaml
    /// </summary>
    public partial class CharacterView : UserControl, IView
    {
        public IViewModel ViewModel => DataContext as IViewModel;

        public CharacterView()
        {
            DataContext = new CharacterViewModel();
            InitializeComponent();
            ViewModel.View = this;
        }
    }
}
