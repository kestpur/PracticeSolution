using PracticeCommon.Interfaces;

using PracticeViewModel.Payloads;

using Prism.Mvvm;

using PubSub;

namespace PracticeViewModel
{
    /// <summary>
    /// ViewModel used on the MainWindow
    /// </summary>
    public class MainWindowViewModel : BindableBase, IViewModel, ISubscribable
    {
        #region IViewModel

        /// <summary>
        /// The view that this viewmodel is bound to
        /// </summary>
        public IView View { get; set; }

        #endregion IViewModel

        #region Properties

        private bool showCreator;

        /// <summary>
        /// The show character creator property
        /// </summary>
        public bool ShowCharacterCreator
        {
            get => showCreator;
            set => SetProperty(ref showCreator, value);
        }

        private bool showGame;

        /// <summary>
        /// The show game property
        /// </summary>
        public bool ShowGame
        {
            get => showGame;
            private set => SetProperty(ref showGame, value);
        }

        private string currentImage;
        public string CurrentImage
        {
            get => currentImage;
            set => SetProperty(ref currentImage, value);
        }
        #endregion Properties

        #region Constructor/Destructor

        /// <summary>
        /// The ViewModel constructor
        /// </summary>
        public MainWindowViewModel()
        {
            ShowCharacterCreator = true;
            ShowGame = false;
            SubscribeToPubSubEvents();
            GoToTavern();
        }

        /// <summary>
        /// The ViewModel destructor
        /// </summary>
        ~MainWindowViewModel()
        {
            UnsubscribeFromPubSubEvents();
        }

        #endregion Constructor/Destructor

        #region ISubscribable

        /// <summary>
        /// The PubSub hub used throughout this program
        /// </summary>
        public Hub Hub => Hub.Default;

        /// <summary>
        /// The method used for subscribing to PubSub events
        /// - called in the constructor
        /// </summary>
        public void SubscribeToPubSubEvents()
        {
            Hub.Subscribe<CharacterPayload>(OnSaveCharacter);
        }

        /// <summary>
        /// The method used for unsubscribing to PubSub events
        /// - called in the destructor
        /// </summary>
        public void UnsubscribeFromPubSubEvents()
        {
            Hub.Unsubscribe<CharacterPayload>(this);
        }

        #endregion ISubscribable
        private void GoToTavern()
        {
            CurrentImage = "../Images/medieval-tavern.jpg";
        }

        private void OnSaveCharacter(CharacterPayload payload)
        {
            if (payload.Key.ToUpper() == "SAVE")
            {
                ShowCharacterCreator = false;
                ShowGame = true;
            }
        }
    }
}