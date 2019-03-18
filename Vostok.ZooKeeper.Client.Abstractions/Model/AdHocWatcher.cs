using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents a node watcher that uses an external delegate to process events.
    /// </summary>
    [PublicAPI]
    public class AdHocWatcher : INodeWatcher
    {
        [NotNull]
        private readonly Action<NodeChangedEventType, string> watcher;

        public AdHocWatcher([NotNull] Action<NodeChangedEventType, string> watcher)
        {
            this.watcher = watcher ?? throw new ArgumentNullException(nameof(watcher));
        }

        /// <inheritdoc />
        public Task ProcessEvent(NodeChangedEventType type, string path)
        {
            watcher(type, path);
            return Task.CompletedTask;
        }
    }
}