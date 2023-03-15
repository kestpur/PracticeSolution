using Practice.Model;

namespace Practice.Model.PubSub.Payload
{
    public class CharacterPayload : ICharacterPayload
    {
        /// <summary>
        /// Creates the Character payload for the pubsub functionality
        /// </summary>
        /// <param name="key">the key to listen for.</param>
        /// <param name="payload">the payload for the event.</param>
        public CharacterPayload(string key, Character payload)
        {
            Key = key;
            Payload = payload;
        }

        public string Key { get; }
        public Character Payload { get; }
    }
}
