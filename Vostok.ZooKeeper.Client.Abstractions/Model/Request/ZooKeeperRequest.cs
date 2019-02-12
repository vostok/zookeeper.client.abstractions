using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    [PublicAPI]
    public abstract class ZooKeeperRequest
    {
        protected ZooKeeperRequest([NotNull] string path)
        {
            Path = path;
        }

        [NotNull]
        public string Path { get; }
    }
}