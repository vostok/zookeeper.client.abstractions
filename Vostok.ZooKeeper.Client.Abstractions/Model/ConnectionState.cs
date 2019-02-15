using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    [PublicAPI]
    public enum ConnectionState
    {
        Connected,
        ConnectedReadonly,
        Disconnected,
        Expired
    }
}