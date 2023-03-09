﻿using PracticeCommon;
using PracticeCommon.Interfaces;

using PracticeViewModel.Interfaces;

using Prism.Mvvm;

using PubSub;

using System;

namespace PracticeViewModel
{
    public class CharacterViewModel : BindableBase, ICharacterViewModel, ISubscribable
    {
        // the model for this view model is a character
        private Character model;
        public IModel Model => model;

        public Character Character
        {
            get => model;
            set => SetProperty(ref model, value);
        }
        public IView View { get; set; }
        public Hub Hub => Hub.Default;

        public CharacterViewModel()
        {
            SubscribeToPubSubEvents();
        }
        ~CharacterViewModel()
        {
            UnsubscribeFromPubSubEvents();
        }

        public void SubscribeToPubSubEvents()
        {
            Hub.Subscribe<ICharacterPayload>(OnCharacterSelected);
        }

        private void OnCharacterSelected(ICharacterPayload payload)
        {
            if(payload.Key.ToUpper() == "SELECTED")
            {
                Character = payload.Payload;
            }
        }

        public void UnsubscribeFromPubSubEvents()
        {
            Hub.Unsubscribe<ICharacterPayload>(this);
        }
    }
}
