using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    [PublicAPI]
    public static class ConnectionStateExtensions
    {
        /// <summary>
        /// Returns whether given state is connected.
        /// </summary>
        public static bool IsConnected(this ConnectionState state, bool canBeReadOnly)
        {
            return state == ConnectionState.Connected
                   || canBeReadOnly && state == ConnectionState.ConnectedReadonly;
        }
    }
}