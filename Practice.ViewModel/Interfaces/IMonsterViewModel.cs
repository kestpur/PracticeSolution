using Practice.Common.BaseClasses;
using Practice.Common.Interfaces;

namespace Practice.ViewModel.Interfaces
{
    public interface IMonsterViewModel : IViewModel
    {
        Monster Monster { get; set; }
    }
}
