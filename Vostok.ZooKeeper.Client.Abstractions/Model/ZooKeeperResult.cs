using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
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

    public class CreateZooKeeperResult : ZooKeeperResult<string>
    {
        public string NewPath => Payload;

        public CreateZooKeeperResult(ZooKeeperStatus status, string path, string payload)
            : base(status, path, payload)
        {
        }
    }

    public class DeleteZooKeeperResult : ZooKeeperResult
    {
        public DeleteZooKeeperResult(ZooKeeperStatus status, string path)
            : base(status, path)
        {
        }
    }

    public class SetDataZooKeeperResult : ZooKeeperResult
    {
        public SetDataZooKeeperResult(ZooKeeperStatus status, string path)
            : base(status, path)
        {
        }
    }

    public class ExistsZooKeeperResult : ZooKeeperResult<Stat>
    {
        public bool Exists => Payload != null;
        public Stat Stat => Payload;

        public ExistsZooKeeperResult(ZooKeeperStatus status, string path, Stat stat)
            : base(status, path, stat)
        {
        }
    }

    public class GetChildrenZooKeeperResult : ZooKeeperResult<string[]>
    {
        public string[] Children => Payload;

        public GetChildrenZooKeeperResult(ZooKeeperStatus status, string path, string[] childrenNames)
            : base(status, path, childrenNames)
        {
        }
    }

    // CR(iloktionov): Get rid of ordinary tuples in favor of ValueTuple.
    public class GetChildrenWithStatZooKeeperResult : ZooKeeperResult<Tuple<string[], Stat>>
    {
        public string[] Children => Payload.Item1;
        public Stat Stat => Payload.Item2;

        public GetChildrenWithStatZooKeeperResult(ZooKeeperStatus status, string path, string[] childrenNames, Stat stat)
            : base(status, path, new Tuple<string[], Stat>(childrenNames, stat))
        {
        }
    }

    public class GetDataZooKeeperResult : ZooKeeperResult<Tuple<byte[], Stat>>
    {
        public byte[] Data => Payload.Item1;
        public Stat Stat => Payload.Item2;

        public GetDataZooKeeperResult(ZooKeeperStatus status, string path, byte[] data, Stat stat)
            : base(status, path, new Tuple<byte[], Stat>(data, stat))
        {
        }
    }
}