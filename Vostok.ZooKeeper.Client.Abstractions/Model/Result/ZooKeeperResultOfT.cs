using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// Представляет результат клиентской операции, возвращающей значение.
    /// </summary>
    [PublicAPI]
    public class ZooKeeperResult<TPayload> : ZooKeeperResult
    {
        public ZooKeeperResult(ZooKeeperStatus status, string path, TPayload payload)
            : base(status, path)
        {
            this.payload = payload;
        }

        /// <summary>
        /// В случае успеха возвращает результат операции. В противном случае выбрасывает исключение <see cref="ZooKeeperException"/>. 
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