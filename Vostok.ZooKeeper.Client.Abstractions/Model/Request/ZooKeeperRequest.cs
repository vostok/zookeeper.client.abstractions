using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents base ZooKeeper request with node path.
    /// </summary>
    [PublicAPI]
    public abstract class ZooKeeperRequest
    {
        /// <inheritdoc cref="ZooKeeperRequest" />
        /// <param name="path">Node path.</param>
        protected ZooKeeperRequest([NotNull] string path)
        {
            Path = path;
        }

        /// <summary>
        /// Returns request node path.
        /// </summary>
        [NotNull]
        public string Path { get; }

        /// <summary>
        /// Returns string representation of <see cref="ZooKeeperRequest"/>.
        /// </summary>
        public override string ToString() => $"{nameof(Path)}: {Path}";
    }
}