﻿using Practice.Common.Interfaces;
using Practice.Common.PubSub.Interfaces;
using Practice.Details.GUI.Interfaces;
using Practice.Model;
using Practice.Model.PubSub.Payload;

using Prism.Commands;
using Prism.Mvvm;

using PubSub;

namespace Practice.Details.GUI
{
    /// <summary>
    /// This is the viewmodel used to display the character
    /// </summary>
    public class CharacterViewModel : BindableBase, ICharacterViewModel, ISubscribable
    {
        #region Commands

        public DelegateCommand CloseCommand { get; private set; }

        #endregion Commands

        #region ICharacterViewModel

        /// <summary>
        /// The view that this viewmodel is bound to
        /// </summary>
        public IView View { get; set; }

        #endregion ICharacterViewModel

        #region Properties

        private Character model;

        public IModel Model => model;

        /// <summary>
        /// The Character to display
        /// </summary>
        public Character Character
        {
            get => model;
            set => SetProperty(ref model, value);
        }

        private bool showCharacter;

        /// <summary>
        /// The ShowCharacter View flag
        /// </summary>
        public bool ShowCharacter
        {
            get => showCharacter;
            set => SetProperty(ref showCharacter, value);
        }

        #endregion Properties

        #region Constructors/Destructor

        public CharacterViewModel()
        {
            SubscribeToPubSubEvents();
            CreateCommands();
        }

        ~CharacterViewModel()
        {
            UnsubscribeFromPubSubEvents();
        }

        #endregion Constructors/Destructor

        #region ISubscribable

        public Hub Hub => Hub.Default;

        public void SubscribeToPubSubEvents()
        {
            Hub.Subscribe<CharacterPayload>(OnCharacterSelected);
        }

        public void UnsubscribeFromPubSubEvents()
        {
            Hub.Unsubscribe<CharacterPayload>(this);
        }

        #endregion ISubscribable

        #region Event Handlers
        private void CreateCommands()
        {
            CloseCommand = new DelegateCommand(OnClose, CanClose);
        }

        private bool CanClose()
        {
            return true;
        }

        private void OnClose()
        {
            Character = null;
            ShowCharacter = false;
        }

        private void OnCharacterSelected(CharacterPayload payload)
        {
            if (payload.Key.ToUpper() == "SELECTED")
            {
                Character = payload.Payload;
                ShowCharacter = true;
            }
            if (payload.Key.ToUpper() == "NONE_SELECTED")
            {
                Character = null;
                ShowCharacter = false;
            }
        }
        #endregion
    }
}