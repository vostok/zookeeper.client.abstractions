using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    [PublicAPI]
    public abstract class ZooKeeperRequest
    {
        /// <param name="path">Absolute path to the node being acted upon.</param>
        protected ZooKeeperRequest([NotNull] string path)
        {
            Path = path;
        }

        /// <summary>
        /// Absolute path to the node being acted upon.
        /// </summary>
        [NotNull]
        public string Path { get; }

        public override string ToString() => $"{nameof(Path)}: '{Path}'";
    }
}