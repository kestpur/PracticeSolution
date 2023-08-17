using Practice.Common.Interfaces;
using Practice.Model;

namespace Practice.ViewModel.Interfaces
{
    public interface ICharacterViewModel : IViewModel
    {
        Character Character { get; set; }
    }
}
