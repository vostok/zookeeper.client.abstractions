using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    [PublicAPI]
    public enum ConnectionStateChangedEvent
    {
        Connected,
        Disconnected,
        Expired
    }
}