using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper set data request.
    /// </summary>
    [PublicAPI]
    public class SetDataRequest : ZooKeeperRequest
    {
        /// <inheritdoc/>
        /// <summary>
        /// Creates a new instance of <see cref="GetDataRequest"/>.
        /// </summary>
        /// <param name="path">Path of node.</param>
        /// <param name="data">Data of node to be saved.</param>
        public SetDataRequest([NotNull] string path, byte[] data)
            : base(path)
        {
            Data = data;
        }

        /// <summary>
        /// Data of node to be saved.
        /// </summary>
        public byte[] Data { get; }

        /// <summary>
        /// <para>Request will be successful if <see cref="Version"/> matches the current version of the node.</para>
        /// <para>If the given version is -1, it matches any node's versions.</para>
        /// </summary>
        public int Version { get; set; } = -1;

        /// <summary>
        /// Returns string representation of <see cref="SetDataRequest"/>.
        /// </summary>
        public override string ToString() => $"SET DATA {base.ToString()}, {nameof(Data)} length: {Data?.Length}, {nameof(Version)}: {Version}";
    }
}