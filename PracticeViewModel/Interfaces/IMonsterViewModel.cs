using Practice.Common.BaseClasses;
using Practice.Common.Interfaces;

namespace PracticeViewModel.Interfaces
{
    public interface IMonsterViewModel : IViewModel
    {
        Monster Monster { get; set; }
    }
}
