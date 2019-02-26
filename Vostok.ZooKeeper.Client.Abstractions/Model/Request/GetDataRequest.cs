using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <inheritdoc/>
    /// <summary>
    /// Represents ZooKeeper get data request.
    /// </summary>
    [PublicAPI]
    public class GetDataRequest : GetRequest
    {
        /// <inheritdoc/>
        /// <summary>
        /// Creates a new instance of <see cref="GetDataRequest"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        public GetDataRequest([NotNull] string path)
            : base(path)
        {
        }

        /// <summary>
        /// Returns string representation of <see cref="GetDataRequest"/>.
        /// </summary>
        public override string ToString() => $"GET DATA {base.ToString()}";
    }
}