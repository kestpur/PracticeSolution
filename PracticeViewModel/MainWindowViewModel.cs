using PracticeCommon.Interfaces;

using PracticeViewModel.Payloads;

using Prism.Mvvm;

using PubSub;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeViewModel
{
    public class MainWindowViewModel : BindableBase, IViewModel, ISubscribable
    {
        public IView View { get; set; }
        public Hub Hub => Hub.Default;

        private bool showCreator;
        public bool ShowCharacterCreator
        {
            get => showCreator;
            set => SetProperty(ref showCreator, value);
        }
        private bool showGame;
        public bool ShowGame
        {
            get => showGame;
            private set => SetProperty(ref showGame, value);
        }
        public MainWindowViewModel()
        {
            ShowCharacterCreator = true;
            ShowGame = false;
            SubscribeToPubSubEvents();
        }
        ~MainWindowViewModel()
        {
            UnsubscribeFromPubSubEvents();
        }

        public void SubscribeToPubSubEvents()
        {
            Hub.Subscribe<CharacterPayload>(OnSaveCharacter);
        }

        private void OnSaveCharacter(CharacterPayload payload)
        {
            if(payload.Key.ToUpper() == "SAVE")
            {
                ShowCharacterCreator = false;
                ShowGame = true;
            }
        }

        public void UnsubscribeFromPubSubEvents()
        {
            Hub.Unsubscribe<CharacterPayload>(this);
        }
    }
}
