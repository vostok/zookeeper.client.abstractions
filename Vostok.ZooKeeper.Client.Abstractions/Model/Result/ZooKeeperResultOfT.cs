using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// Represents a ZooKeeper generic operation result with node path, status and payload in case of success.
    /// </summary>
    [PublicAPI]
    public class ZooKeeperResult<TPayload> : ZooKeeperResult
    {
        [CanBeNull]
        private readonly TPayload payload;

        public ZooKeeperResult(ZooKeeperStatus status, [NotNull] string path, [CanBeNull] TPayload payload)
            : base(status, path)
        {
            this.payload = payload;
        }

        /// <summary>
        /// <para>Returns the payload if this result's <see cref="ZooKeeperResult.IsSuccessful"/> property returns <c>true</c>.</para>
        /// <para>Throws a <see cref="ZooKeeperException"/> otherwise.</para>
        /// </summary>
        protected TPayload Payload
        {
            get
            {
                EnsureSuccess();
                return payload;
            }
        }
    }
}