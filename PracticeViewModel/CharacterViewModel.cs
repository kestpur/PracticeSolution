using PracticeCommon;
using PracticeCommon.Interfaces;

using PracticeViewModel.Interfaces;

using Prism.Mvvm;

using PubSub;

namespace PracticeViewModel
{
    public class CharacterViewModel : BindableBase, ICharacterViewModel, ISubscribable
    {
        #region ICharacterViewModel
        /// <summary>
        /// The view that this viewmodel is bound to
        /// </summary>
        public IView View { get; set; }
        #endregion
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
        #endregion
        #region Constructors/Destructor
        public CharacterViewModel()
        {
            SubscribeToPubSubEvents();
        }

        ~CharacterViewModel()
        {
            UnsubscribeFromPubSubEvents();
        }
        #endregion
        #region ISubscribable
        public Hub Hub => Hub.Default;
        public void SubscribeToPubSubEvents()
        {
            Hub.Subscribe<ICharacterPayload>(OnCharacterSelected);
        }

        public void UnsubscribeFromPubSubEvents()
        {
            Hub.Unsubscribe<ICharacterPayload>(this);
        }
        #endregion

        private void OnCharacterSelected(ICharacterPayload payload)
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
    }
}