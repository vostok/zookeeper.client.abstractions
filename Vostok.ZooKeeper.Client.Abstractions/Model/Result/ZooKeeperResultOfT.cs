using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// Represents base ZooKeeper node result with path, status and some payload.
    /// </summary>
    [PublicAPI]
    public class ZooKeeperResult<TPayload> : ZooKeeperResult
    {
        /// <summary>
        /// Creates a new instance of <see cref="ZooKeeperResult"/>.
        /// </summary>
        /// <param name="status">Operation status.</param>
        /// <param name="path">Path of node.</param>
        /// <param name="payload">Result payload.</param>
        public ZooKeeperResult(ZooKeeperStatus status, string path, TPayload payload)
            : base(status, path)
        {
            this.payload = payload;
        }

        /// <summary>
        /// In case of success returns result payload, else throws <see cref="ZooKeeperException"/>.
        /// </summary>
        protected TPayload Payload
        {
            get
            {
                EnsureSuccess();
                return payload;
            }
        }

        private readonly TPayload payload;
    }
}