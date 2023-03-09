using PracticeCommon.Interfaces;

using PracticeCommon;
using PracticeCommon.BaseClasses;
using PracticeCommon.Monsters;

using PracticeViewModel.Interfaces;
using PracticeViewModel.Payloads;

using Prism.Mvvm;

using PubSub;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace PracticeViewModel
{
    /// <summary>
    /// this is used to display a list of creatures (monsters or characters)
    /// </summary>
    public class MultipleCreaturesViewModel : BindableBase,
        IMultipleCreaturesViewModel, ISubscribable
    {
        public DelegateCommand RemoveCharacterCommand { get; private set; }

        private ObservableCollection<Creature> creatures = new ObservableCollection<Creature>();
        public ObservableCollection<Creature> Creatures
        {
            get => creatures;
        }
        private Creature selectedCreature;
        public Creature SelectedCreature
        {
            get => selectedCreature;
            set
            {
                SetProperty(ref selectedCreature, value);
                Hub.Publish(new CharacterPayload("Selected", selectedCreature as Character));
            }
        }

        public IView View { get; set; }
        public Hub Hub => Hub.Default;

        public MultipleCreaturesViewModel()
        {
            SubscribeToPubSubEvents();
        }
        ~MultipleCreaturesViewModel()
        {
            UnsubscribeFromPubSubEvents();
        }

        #region Methods
        public void AddCreature(Creature creature)
        {
            creatures.Add(creature);
        }
        #endregion

        #region PubSub Functions
        public void SubscribeToPubSubEvents()
        {
            Hub.Subscribe<CharacterPayload>(OnAddCharacter);
        }
        public void UnsubscribeFromPubSubEvents()
        {
            Hub.Unsubscribe<CharacterPayload>(this);
        }

        private void OnAddCharacter(CharacterPayload payload)
        {
            if (payload.Key.ToUpper() == "SAVE")
            {
                AddCreature(payload.Payload);
            }
        }

        #endregion
    }
}
