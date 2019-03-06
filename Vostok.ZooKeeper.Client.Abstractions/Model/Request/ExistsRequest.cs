using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <inheritdoc/>
    /// <summary>
    /// Represents ZooKeeper exists node request.
    /// </summary>
    [PublicAPI]
    public class ExistsRequest : GetRequest
    {
        /// <inheritdoc/>
        /// <summary>
        /// Creates a new instance of <see cref="ExistsRequest"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        public ExistsRequest([NotNull] string path)
            : base(path)
        {
        }

        /// <summary>
        /// Returns string representation of <see cref="ExistsRequest"/>.
        /// </summary>
        public override string ToString() => $"EXISTS {base.ToString()}";

        /// <summary>
        /// Creates a new instance of <see cref="ExistsRequest"/> with given <paramref name="path"/>.
        /// </summary>
        public static implicit operator ExistsRequest([NotNull] string path) => new ExistsRequest(path);
    }
}