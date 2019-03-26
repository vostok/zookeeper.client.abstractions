using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents a node onEvent that uses an external delegate to process events.
    /// </summary>
    [PublicAPI]
    public class AdHocNodeWatcher : INodeWatcher
    {
        [NotNull]
        private readonly Action<NodeChangedEventType, string> onEvent;

        public AdHocNodeWatcher([NotNull] Action<NodeChangedEventType, string> onEvent)
        {
            this.onEvent = onEvent ?? throw new ArgumentNullException(nameof(onEvent));
        }

        /// <inheritdoc />
        public Task ProcessEvent(NodeChangedEventType type, string path)
        {
            onEvent(type, path);
            return Task.CompletedTask;
        }
    }
}