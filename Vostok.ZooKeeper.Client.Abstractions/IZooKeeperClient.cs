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
        /// <para>Returns an observable of client connection state.</para>
        /// <para>Calls <see cref="IObserver{T}.OnNext"/> on each connection state changed.</para>
        /// <para>May calls <see cref="IObserver{ConnectionState}.OnCompleted"/> if client implementation is disposed.</para>
        /// <para>Does not call <see cref="IObserver{ConnectionState}.OnError"/></para>
        /// <para>All calls are consequent.</para>
        /// <para>All transitions between <see cref="ConnectionState"/> are possible.</para>
        /// </summary>
        IObservable<ConnectionState> OnConnectionStateChanged { get; }

        /// <summary>
        /// <para>Returns client connection state.</para>
        /// <para>Initial connection state is <see cref="F:ConnectionState.Disconnected"/>.</para>
        /// </summary>
        ConnectionState ConnectionState { get; }

        /// <summary>
        /// Returns client session id or 0 if not connected.
        /// </summary>
        long SessionId { get; }

        /// <summary>
        /// <para>Creates new node using given <paramref name="request" />.</para>
        /// <para>By default, all parent nodes will be created if they do not exist.</para>
        /// <para>In case of unsuccessful, result of this operation is not guaranteed.</para>
        /// </summary>
        Task<CreateResult> CreateAsync(CreateRequest request);

        /// <summary>
        /// <para>Deletes the node using given <paramref name="request"/>.</para>
        /// <para>By default, all children nodes will be deleted if they exist.</para>
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