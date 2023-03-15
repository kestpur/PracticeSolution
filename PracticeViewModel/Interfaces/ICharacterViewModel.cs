using Practice.Common.Interfaces;
using Practice.Model;

namespace PracticeViewModel.Interfaces
{
    public interface ICharacterViewModel : IViewModel
    {
        Character Character { get; set; }
    }
}
