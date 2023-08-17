using Practice.Common.Interfaces;
using Practice.Creation.ViewModels;

using System.Windows.Controls;

namespace Practice.Character.Creation.Views
{
    /// <summary>
    /// Interaction logic for CreateCharacterView.xaml
    /// </summary>
    public partial class CreateCharacterView : UserControl, IView
    {
        public CreateCharacterView()
        {

            DataContext = new CreateCharacterViewModel();
            InitializeComponent();

            ViewModel.View = this;
        }

        public IViewModel ViewModel => DataContext as IViewModel;
    }
}
