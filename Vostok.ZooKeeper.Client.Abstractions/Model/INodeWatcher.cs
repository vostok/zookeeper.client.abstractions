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
        /// <para>Processes the specified event with given <paramref name="type"/> and node <paramref name="path"/>.</para>
        /// <para>All calls are consequent. So, you should not process event for a long time.</para>
        /// </summary>
        Task ProcessEvent(NodeChangedEventType type, [NotNull] string path);
    }
}