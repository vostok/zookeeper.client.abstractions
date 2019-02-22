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
        /// <param name="path">Path of node.</param>
        protected ZooKeeperRequest([NotNull] string path)
        {
            Path = path;
        }

        /// <summary>
        /// Path of node.
        /// </summary>
        [NotNull]
        public string Path { get; set; }

        /// <summary>
        /// Returns string representation of <see cref="ZooKeeperRequest"/>.
        /// </summary>
        public override string ToString() => $"{nameof(Path)}: {Path}";
    }
}