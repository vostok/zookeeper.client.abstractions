using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    [PublicAPI]
    public static class ZooKeeperResultExtensions
    {
        /// <summary>
        /// Returns whether given <paramref name="result"/> unsuccessful and can be retried later.
        /// </summary>
        public static bool IsRetriableNetworkError([NotNull] this ZooKeeperResult result) =>
            result.Status == ZooKeeperStatus.UnknownError ||
            result.Status == ZooKeeperStatus.NotConnected ||
            result.Status == ZooKeeperStatus.ConnectionLoss ||
            result.Status == ZooKeeperStatus.SessionExpired ||
            result.Status == ZooKeeperStatus.SessionMoved ||
            result.Status == ZooKeeperStatus.Timeout;
    }
}