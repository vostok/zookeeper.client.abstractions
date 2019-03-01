using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;
using Vostok.ZooKeeper.Client.Abstractions.Model.Result;

namespace Vostok.ZooKeeper.Client.Abstractions
{
    /// <summary>
    /// <para>Represents a client for ZooKeeper.</para>
    /// <para>Nodes in a ZooKeeper comprise a tree, and the main operations this client presents is create, delete, get, set node by path.</para>
    /// </summary>
    [PublicAPI]
    public interface IZooKeeperClient
    {
        /// <summary>
        /// Returns an observable of client connection state.
        /// </summary>
        IObservable<ConnectionState> OnConnectionStateChanged { get; }

        /// <summary>
        /// Returns client connection state.
        /// </summary>
        ConnectionState ConnectionState { get; }

        /// <summary>
        /// Returns client session id or 0 if not connected.
        /// </summary>
        long SessionId { get; }

        /// <summary>
        /// Returns client session password or null if not connected.
        /// </summary>
        byte[] SessionPassword { get; }

        /// <summary>
        /// <para>Creates new node using given <paramref name="request" />.</para>
        /// <para>In case of unsuccessful, result of this operation is not guaranteed.</para>
        /// <para>This operation, if successful, will trigger all the <see cref="INodeWatcher"/> watchers left on the node.</para>
        /// </summary>
        Task<CreateResult> CreateAsync(CreateRequest request);

        /// <summary>
        /// Deletes the node using given <paramref name="request"/>.
        /// </summary>
        Task<DeleteResult> DeleteAsync(DeleteRequest request);

        /// <summary>
        /// Sets the data for the node using given <paramref name="request" />.
        /// </summary>
        Task<SetDataResult> SetDataAsync(SetDataRequest request);

        /// <summary>
        /// Checks whether the node exists or not using given <paramref name="request" />.
        /// </summary>
        Task<ExistsResult> ExistsAsync(ExistsRequest request);

        /// <summary>
        /// Returns the stat and children list for given <paramref name="request" />.
        /// </summary>
        Task<GetChildrenResult> GetChildrenAsync(GetChildrenRequest request);

        /// <summary>
        /// Returns the data and the stat of the node using given <paramref name="request" />.
        /// </summary>
        Task<GetDataResult> GetDataAsync(GetDataRequest request);
    }
}