using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    [PublicAPI]
    public static class ZooKeeperStatusExtensions
    {
        public static bool IsNetworkError(this ZooKeeperStatus status) =>
            status == ZooKeeperStatus.UnknownError ||
            status == ZooKeeperStatus.NotConnected ||
            status == ZooKeeperStatus.ConnectionLoss ||
            status == ZooKeeperStatus.SessionExpired ||
            status == ZooKeeperStatus.SessionMoved ||
            status == ZooKeeperStatus.Timeout ||
            status == ZooKeeperStatus.NotReadonlyOperation;
    }
}