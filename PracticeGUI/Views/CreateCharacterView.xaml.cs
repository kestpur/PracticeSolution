using Practice.Common.Interfaces;

using PracticeViewModel;

using System.Windows.Controls;

namespace PracticeGUI.Views
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
