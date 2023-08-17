using Practice.Common.Interfaces;

using Practice.ViewModel;

using System.Windows.Controls;

namespace Practice.GUI.Views
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
