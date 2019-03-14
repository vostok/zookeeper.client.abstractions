using System.Threading.Tasks;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents a node event watcher. <see cref="INodeWatcher"/>s can be set on ZooKeeper nodes with read operations represented by <see cref="ExistsRequest"/>, <see cref="GetChildrenRequest"/> and <see cref="GetDataRequest"/>.
    /// </summary>
    [PublicAPI]
    public interface INodeWatcher
    {
        /// <summary>
        /// <para>Processes the specified event with given <paramref name="type"/> and node <paramref name="path"/>.</para>
        /// <para>Watcher implementations should not block, wait or acquire locks in this method as node events are usually handled sequentially by client implementations.</para>
        /// </summary>
        Task ProcessEvent(NodeChangedEventType type, [NotNull] string path);
    }
}