using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Common.PubSub.Interfaces
{
    /// <summary>
    /// Interface required for PubSub payloads
    /// </summary>
    /// <typeparam name="T">the type of the payload</typeparam>
    public interface IPubSubPayload<out T>
    {
        /// <summary>
        /// Gets the key for this Payload, used by subscribers to know this specific PubSub applies to them
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        string Key { get; }

        /// <summary>
        /// Gets the pay load.
        /// </summary>
        /// <value>
        /// The pay load.
        /// </value>
        T Payload { get; }
    }
}
