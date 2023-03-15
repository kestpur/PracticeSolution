using PubSub;

namespace Practice.Common.PubSub.Interfaces
{
    /// <summary>
    /// The ISubscribable interface for common functions that use PubSub
    /// </summary>
    public interface ISubscribable
    {
        Hub Hub { get; }

        /// <summary>
        /// Subscribes to pub sub events.
        /// </summary>
        void SubscribeToPubSubEvents();

        /// <summary>
        /// Unsubscribe from pub sub events.
        /// </summary>
        void UnsubscribeFromPubSubEvents();
    }
}
