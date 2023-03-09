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

        public DelegateCommand RollCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand RenameCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        public IView View { get; set; }
        private Character model;
        public ICreature Model => model;
        public Character Character
        {
            get => model;
            set => SetProperty(ref model, value);
        }
        public Hub Hub => Hub.Default;

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
        public IEnumerable<CharacterRace> CharacterRaceValues
        {
            get
            {
                return Enum.GetValues(typeof(CharacterRace))
                    .Cast<CharacterRace>();
            }
        }
        public IEnumerable<CharacterClass> CharacterClassValues
        {
            get
            {
                return Enum.GetValues(typeof(CharacterClass))
                    .Cast<CharacterClass>();
            }
        }

        #region Construction
        public CreateCharacterViewModel()
        {
            var character = new Character();
            character.Init();

            RollCommand = new DelegateCommand(OnRoll, CanRoll);
            SaveCommand = new DelegateCommand(OnSave, CanSave);
            RenameCommand = new DelegateCommand(OnRename, CanRename);
            CancelCommand = new DelegateCommand(OnCancel, CanCancel);

            Character = character;
            SubscribeToPubSubEvents();
        }
        ~CreateCharacterViewModel()
        {
            UnsubscribeFromPubSubEvents();
        }
        #endregion
        #region Event Functions
        private void OnCancel()
        {

        }
        private bool canCancel = false;
        private bool CanCancel() { return canCancel; }
        private void OnRoll()
        {
            model.Init();
        }
        private bool CanRoll() { return true; }

        private void OnSave()
        {
            // this needs to let the next view models to be created and displayed
            var payload = new CharacterPayload("save", Character);
            Hub.Publish(payload);
        }
        private bool CanSave() { return true; }

        private void OnRename()
        {
            // this needs to let the current view allow the name to be changed
        }
        private bool CanRename() { return false; }
        #endregion
        #region PubSub Functions
        public void SubscribeToPubSubEvents()
        {
        }

        public void UnsubscribeFromPubSubEvents()
        {
        }
        #endregion
    }
}
