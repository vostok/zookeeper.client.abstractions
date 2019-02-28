using System.Threading.Tasks;
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
        /// Processes the specified event with given <paramref name="type"/>, <paramref name="connectionState"/> and node <paramref name="path"/>.
        /// </summary>
        Task ProcessEvent(NodeChangedEventType type, ConnectionState connectionState, string path);
    }
}