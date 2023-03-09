using PracticeCommon.Interfaces;

using PracticeViewModel;
using PracticeViewModel.Interfaces;

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
