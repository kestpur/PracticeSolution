using PracticeCommon.Interfaces;

using Prism.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeViewModel.Interfaces
{
    public interface ICreateCharacterViewModel : IViewModel
    {
        DelegateCommand RollCommand { get; }
        DelegateCommand SaveCommand { get; }
        DelegateCommand RenameCommand { get; }

    }
}
