using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents base ZooKeeper node request with path.
    /// </summary>
    [PublicAPI]
    public abstract class ZooKeeperRequest
    {
        /// <summary>
        /// Creates a new instance of <see cref="ZooKeeperRequest"/>
        /// </summary>
        /// <param name="path">Absolute, slash-separated path of node.</param>
        protected ZooKeeperRequest([NotNull] string path)
        {
            Path = path;
        }

        /// <summary>
        /// Absolute, slash-separated path of node.
        /// </summary>
        [NotNull]
        public string Path { get; }

        /// <summary>
        /// Returns string representation of <see cref="ZooKeeperRequest"/>.
        /// </summary>
        public override string ToString() => $"{nameof(Path)}: {Path}";
    }
}