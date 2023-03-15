using Practice.Common.BaseClasses;
using Practice.Common.Interfaces;

using PracticeViewModel.Interfaces;

using Prism.Mvvm;

namespace PracticeViewModel
{
    public class MonsterViewModel : BindableBase, IMonsterViewModel
    {
        Monster model;
        public MonsterViewModel() { }
        public IModel Model => model;
        public Monster Monster
        {
            get => model;
            set => SetProperty(ref model, value);
        }
        public IView View { get; set; }
    }
}
