using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper data update request.
    /// </summary>
    [PublicAPI]
    public class UpdateDataRequest : ZooKeeperRequest
    {
        /// <param name="path">Full path to the node being updated.</param>
        /// <param name="updateFunc">Node data update delegate.</param>
        /// <param name="attempts">Optimistic update attempts.</param>
        public UpdateDataRequest([NotNull] string path, [NotNull] Func<byte[], byte[]> updateFunc, int attempts = 5)
            : base(path)
        {
            UpdateFunc = updateFunc;
            Attempts = attempts;
        }

        /// <summary>
        /// <para>Optimistic update attempts.</para>
        /// </summary>
        public int Attempts { get; }

        /// <summary>
        /// <para>Node data update delegate.</para>
        /// </summary>
        [NotNull]
        public Func<byte[], byte[]> UpdateFunc { get; }

        public override string ToString()
            => $"UPDATE DATA for '{Path}'; attempts = {Attempts}";
    }
}