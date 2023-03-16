using Practice.Common.Interfaces;
using Practice.Model;

namespace Practice.Details.GUI.Interfaces
{
    public interface ICharacterViewModel : IViewModel
    {
        Character Character { get; set; }
    }
}
