using Practice.Character.Creation.Views;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeCharacterCreation
{
    /// <summary>
    /// TODO: Make sure the Region is setup correctly within the main window
    /// </summary>
    [Module(ModuleName = "CharacterCreationModule", OnDemand = false)]
    public class CharacterCreationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(CreateCharacterView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterForNavigation<PersonDetail>();
        }
    }
}
