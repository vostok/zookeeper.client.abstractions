using System;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents a node watcher which uses action to process events.
    /// </summary>
    [PublicAPI]
    public class AdHocWatcher : INodeWatcher
    {
        private readonly Action<NodeChangedEventType, ConnectionState, string> processingDelegate;

        /// <summary>
        /// Creates a new instance of <see cref="AdHocWatcher"/>.
        /// </summary>
        /// <param name="processingDelegate">Delegate for node events processing. Recieves <see cref="NodeChangedEventType"/>, <see cref="ConnectionState"/> and node path.</param>
        public AdHocWatcher(Action<NodeChangedEventType, ConnectionState, string> processingDelegate)
        {
            this.processingDelegate = processingDelegate;
        }

        /// <inheritdoc />
        public Task ProcessEvent(NodeChangedEventType type, ConnectionState connectionState, string path)
        {
            processingDelegate(type, connectionState, path);
            return Task.CompletedTask;
        }
    }
}