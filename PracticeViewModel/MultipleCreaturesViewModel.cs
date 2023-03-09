using PracticeCommon;
using PracticeCommon.BaseClasses;
using PracticeCommon.Interfaces;

using PracticeViewModel.Interfaces;
using PracticeViewModel.Payloads;

using Prism.Commands;
using Prism.Mvvm;

using PubSub;

using System.Collections.ObjectModel;

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
                if (value != null) Hub.Publish(new CharacterPayload("Selected", selectedCreature as Character));
                else Hub.Publish(new CharacterPayload("None_Selected", null));
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

        #endregion Methods

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

        #endregion PubSub Functions
    }
}