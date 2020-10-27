using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions
{
    internal static class IZooKeeperClientExtensions_Misc
    {
        [NotNull]
        public static IZooKeeperAuthClient AsAuthZooKeeperClient([NotNull] this IZooKeeperClient client)
            => client as IZooKeeperAuthClient ?? throw new NotSupportedException($"This zookeeper client of type '{client.GetType().Name}' does not support authentication.");

    }
}