using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    [PublicAPI]
    public class ZooKeeperException : Exception
    {
        public ZooKeeperException(ZooKeeperStatus status, string path)
            : base($"ZooKeeper operation has failed with status '{status}' for path '{path}'.") { }
    }
}