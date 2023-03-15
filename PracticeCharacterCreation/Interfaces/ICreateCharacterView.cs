
using Practice.Common.Interfaces;

using Prism.Commands;

namespace Practice.Character.Creation.Interfaces
{
    public interface ICreateCharacterViewModel : IViewModel
    {
        DelegateCommand RollCommand { get; }
        DelegateCommand SaveCommand { get; }
        DelegateCommand RenameCommand { get; }

    }
}
