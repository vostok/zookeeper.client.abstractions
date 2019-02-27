using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents an node event handler class.
    /// </summary>
    [PublicAPI]
    public interface INodeWatcher
    {
        /// <summary>
        /// Processes the specified event with given <paramref name="type"/> and node <paramref name="path"/>.
        /// </summary>
        void ProcessEvent(NodeChangedEventType type, string path);
    }
}