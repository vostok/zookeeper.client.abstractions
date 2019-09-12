using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper update data request.
    /// </summary>
    [PublicAPI]
    public class UpdateDataRequest : ZooKeeperRequest
    {
        /// <param name="path">Full path to the node being updated.</param>
        /// <param name="update">Node data update delegate.</param>
        public UpdateDataRequest([NotNull] string path, [NotNull] Func<byte[], byte[]> update)
            : base(path)
        {
            Update = update ?? throw new ArgumentNullException(nameof(update));
        }

        /// <summary>
        /// <para>Amount of update attempts.</para>
        /// </summary>
        public int Attempts { get; set; } = 5;

        /// <summary>
        /// <para>Node data update delegate.</para>
        /// </summary>
        [NotNull]
        public Func<byte[], byte[]> Update { get; }

        public override string ToString()
            => $"UPDATE DATA for '{Path}'; attempts = {Attempts}";
    }
}