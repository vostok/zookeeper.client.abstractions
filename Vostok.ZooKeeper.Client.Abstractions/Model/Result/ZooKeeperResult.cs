using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Result
{
    /// <summary>
    /// Представляет результат клиентской операции.
    /// </summary>
    [PublicAPI]
    public class ZooKeeperResult
    {
        public ZooKeeperResult(ZooKeeperStatus status, string path)
        {
            Status = status;
            Path = path;
        }

        /// <summary>
        /// Возвращает true, если операция завершилась успешно.
        /// </summary>
        public bool IsSuccessful()
        {
            return Status == ZooKeeperStatus.Ok;
        }


        // CR(iloktionov): Remove IsXXX() methods.
        /// <summary>
        /// Возвращает true, если операция завершилась с системной ошибкой (проблемы с соединением, клиентские исключения).
        /// </summary>
        public bool IsSystemError()
        {
            return Status < ZooKeeperStatus.Ok && Status > ZooKeeperStatus.NoNode;
        }

        /// <summary>
        /// Возвращает true, если операция завершилась осмысленной ошибкой (предусмотренной протоколом ZK).
        /// </summary>
        public bool IsApiError()
        {
            return Status <= ZooKeeperStatus.NoNode;
        }

        /// <summary>
        /// В случае неуспешного статуса выбрасывает исключение <see cref="ZooKeeperException"/>. 
        /// </summary>
        public ZooKeeperResult EnsureSuccess()
        {
            if (!IsSuccessful())
                throw new ZooKeeperException(Status, Path);
            return this;
        }

        public override string ToString()
        {
            return string.Format("'{0}' for path '{1}'", Status, Path);
        }

        /// <summary>
        /// Статус операции.
        /// </summary>
        public ZooKeeperStatus Status { get; private set; }

        /// <summary>
        /// Путь ноды, соответствующей операции.
        /// </summary>
        public string Path { get; private set; }
    }

    
}