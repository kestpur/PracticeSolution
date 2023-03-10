using PracticeCommon;
using PracticeCommon.Enums;
using PracticeCommon.Interfaces;

using PracticeViewModel.Interfaces;
using PracticeViewModel.Payloads;

using Prism.Commands;
using Prism.Mvvm;

using PubSub;

using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeViewModel
{
    public class CreateCharacterViewModel : BindableBase,
        ICreateCharacterViewModel, ISubscribable
    {
        #region Commands

        public DelegateCommand RollCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand RenameCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        #endregion Commands

        #region ICreateCharacterViewModel

        public IView View { get; set; }

        #endregion ICreateCharacterViewModel

        #region Properties

        private Character model;
        public ICreature Model => model;

        public Character Character
        {
            get => model;
            set => SetProperty(ref model, value);
        }

        public CharacterRace SelectedRace
        {
            get => model.CharacterRace;
            set => model.CharacterRace = value;
        }

        public CharacterClass SelectedClass
        {
            get => model.CharacterClass;
            set => model.CharacterClass = value;
        }

        /// <summary>
        /// CharacterRaceValues used to display in the dropdown
        /// </summary>
        public IEnumerable<CharacterRace> CharacterRaceValues
        {
            get
            {
                return Enum.GetValues(typeof(CharacterRace))
                    .Cast<CharacterRace>();
            }
        }

        /// <summary>
        /// CharacterClassValues used to display in the dropdown
        /// </summary>
        public IEnumerable<CharacterClass> CharacterClassValues
        {
            get
            {
                return Enum.GetValues(typeof(CharacterClass))
                    .Cast<CharacterClass>();
            }
        }

        #endregion Properties

        #region Construction

        /// <summary>
        /// Constructor for this ViewModel
        /// </summary>
        public CreateCharacterViewModel()
        {
            var character = new Character();
            character.Init();
            character.IsPlayer = true;

            CreateCommands();

            Character = character;
            SubscribeToPubSubEvents();
        }

        /// <summary>
        /// Destructor for this ViewModel
        /// </summary>
        ~CreateCharacterViewModel()
        {
            UnsubscribeFromPubSubEvents();
        }

        #endregion Construction

        #region Event Functions

        /// <summary>
        /// Create the Commands used by this ViewModel
        /// </summary>
        private void CreateCommands()
        {
            RollCommand = new DelegateCommand(OnRoll, CanRoll);
            SaveCommand = new DelegateCommand(OnSave, CanSave);
        }

        /// <summary>
        /// This rolls the dice for the character stats
        /// </summary>
        private void OnRoll()
        {
            model.Init();
        }

        private bool CanRoll()
        { return true; }

        /// <summary>
        /// This saves the character that was built
        /// - Currently application only moves the character to the next screen
        /// </summary>
        private void OnSave()
        {
            var payload = new CharacterPayload("save", Character);
            Hub.Publish(payload);
        }

        private bool CanSave()
        { return true; }

        #endregion Event Functions

        #region ISubscribable
        public Hub Hub => Hub.Default;
        /// <summary>
        /// The method used for subscribing to PubSub events
        /// - called in the constructor
        /// </summary>
        public void SubscribeToPubSubEvents()
        {
        }

        /// <summary>
        /// The method used for unsubscribing to PubSub events
        /// - called in the destructor
        /// </summary>
        public void UnsubscribeFromPubSubEvents()
        {
        }

        #endregion ISubscribable
    }
}