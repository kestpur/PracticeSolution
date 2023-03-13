using PracticeCommon.Interfaces;

using PracticeViewModel;

using System.Windows.Controls;

namespace PracticeGUI.Views
{
    /// <summary>
    /// Interaction logic for MultipleCreaturesView.xaml
    /// </summary>
    public partial class MultipleCreaturesView : UserControl, IView
    {
        public MultipleCreaturesView()
        {
            DataContext = new MultipleCreaturesViewModel();
            InitializeComponent();

            ViewModel.View = this;
        }

        public IViewModel ViewModel => DataContext as IViewModel;
    }
}
