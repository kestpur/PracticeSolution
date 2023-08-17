using Practice.Common.BaseClasses;
using Practice.Common.Helpers;
using Practice.Common.Interfaces;
using Practice.Common.PubSub.Interfaces;
using Practice.Model;
using Practice.Model.PubSub.Payload;

using Practice.ViewModel.Interfaces;

using Prism.Commands;
using Prism.Mvvm;

using PubSub;

using System.Collections.ObjectModel;
using System.Linq;

namespace Practice.ViewModel
{
    /// <summary>
    /// this is used to display a list of creatures (monsters or characters)
    /// </summary>
    public class MultipleCreaturesViewModel : BindableBase,
        IMultipleCreaturesViewModel, ISubscribable
    {
        #region Commands
        public DelegateCommand<Creature> RemoveCreatureCommand { get; private set; }
        public DelegateCommand<Creature> LevelUpCommand { get; private set; }
        public DelegateCommand<Creature> ViewCreatureCommand { get; private set; }
        #endregion

        #region Properties
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
        #endregion
        #region IMultipleCreaturesViewModel
        public IView View { get; set; }
        #endregion

        #region Constructors/Destructors
        public MultipleCreaturesViewModel()
        {
            CreateCommands();
            SubscribeToPubSubEvents();
        }

        ~MultipleCreaturesViewModel()
        {
            UnsubscribeFromPubSubEvents();
        }
        #endregion

        #region ISubscribable
        public Hub Hub => Hub.Default;

        public void SubscribeToPubSubEvents()
        {
            Hub.Subscribe<CharacterPayload>(OnAddCharacter);
        }

        public void UnsubscribeFromPubSubEvents()
        {
            Hub.Unsubscribe<CharacterPayload>(this);
        }
        #endregion

        #region Event Functions
        private void CreateCommands()
        {
            RemoveCreatureCommand = new DelegateCommand<Creature>(OnRemoveCreature, CanRemoveCreature);
            LevelUpCommand = new DelegateCommand<Creature>(OnLevelUp, CanLevelUp);
            ViewCreatureCommand = new DelegateCommand<Creature>(OnViewCreature, CanViewCreature);
        }

        private bool CanViewCreature(Creature creature)
        {
            return true;
        }

        /// <summary>
        /// TODO: currently not implemented
        /// </summary>
        /// <param name="obj"></param>
        private void OnViewCreature(Creature creature)
        {
            Hub.Publish(new CharacterPayload("Selected", creature as Character));
        }

        private void OnLevelUp(Creature creature)
        {
            var character = creature as Character;
            if(character != null)
            {
                character.LevelUp();
            }
        }

        private bool CanLevelUp(Creature creature)
        {
            var character = creature as Character;
            if(character != null)
            {
                return CharacterClassHelper.ReadyToLevel(character.XP, character.Level);
            }
            return false;
        }

        private bool CanRemoveCreature(Creature creature)
        {
            var character = creature as Character;
            if (character != null && character.IsPlayer) return false;
            return true;
        }

        private void OnRemoveCreature(Creature creature)
        {
            Creatures.Remove(Creatures.SingleOrDefault(i => i.Name == creature.Name));
        }

        private void OnAddCharacter(CharacterPayload payload)
        {
            if (payload.Key.ToUpper() == "SAVE")
            {
                AddCreature(payload.Payload);
            }
        }
        #endregion

        public void AddCreature(Creature creature)
        {
            creatures.Add(creature);
        }

    }
}