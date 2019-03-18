using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper data write request.
    /// </summary>
    [PublicAPI]
    public class SetDataRequest : ZooKeeperRequest
    {
        /// <param name="path">Full path to the node being written to.</param>
        /// <param name="data">Data being written to the node.</param>
        public SetDataRequest([NotNull] string path, [CanBeNull] byte[] data)
            : base(path)
        {
            Data = data;
        }

        /// <summary>
        /// Data being written to the node.
        /// </summary>
        [CanBeNull]
        public byte[] Data { get; }

        /// <summary>
        /// <para>If set to value other than <c>-1</c>, write will only occur if node's current <see cref="NodeStat.Version"/> equals provided one.</para>
        /// <para>Default value of <c>-1</c> disables version check.</para>
        /// </summary>
        public int Version { get; set; } = -1;

        public override string ToString()
            => $"SET DATA for '{Path}'; Data length = {Data?.Length ?? 0}; Version = {Version}";
    }
}