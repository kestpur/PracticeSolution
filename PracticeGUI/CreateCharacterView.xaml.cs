using PracticeCommon.Interfaces;

using PracticeViewModel;

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

namespace PracticeGUI
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
