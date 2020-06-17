using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;
using Vostok.ZooKeeper.Client.Abstractions.Model.Result;

namespace Vostok.ZooKeeper.Client.Abstractions
{
    /// <summary>
    /// <para>Represents a client for ZooKeeper service.</para>
    /// <para>Nodes in ZooKeeper comprise a tree and are identified by slash-separated paths such as <c>'/foo/bar/baz'</c>.</para>
    /// <para>Client's primary operations acting on these nodes are:</para>
    /// <list type="bullet">
    ///     <item><description><see cref="CreateAsync"/></description></item>
    ///     <item><description><see cref="DeleteAsync"/></description></item>
    ///     <item><description><see cref="ExistsAsync"/></description></item>
    ///     <item><description><see cref="GetChildrenAsync"/></description></item>
    ///     <item><description><see cref="GetDataAsync"/></description></item>
    ///     <item><description><see cref="SetDataAsync"/></description></item>
    /// </list>
    /// </summary>
    [PublicAPI]
    public interface IZooKeeperClient
    {
        /// <summary>
        /// <para>Returns an observable sequence of client connection states.</para>
        /// <para>This sequence produces <see cref="IObserver{T}.OnNext"/> notifications every time current <see cref="ConnectionState"/> changes.</para>
        /// <para>This sequence never produces <see cref="IObserver{T}.OnError"/> notifications, but may produce an <see cref="IObserver{T}.OnCompleted"/> notification when client gets disposed.</para>
        /// <para>Immediately produces a notification with current <see cref="ConnectionState"/> when subscribed to.</para>
        /// <para>All possible transitions between <see cref="ConnectionState"/>s are allowed and valid.</para>
        /// </summary>
        [NotNull]
        IObservable<ConnectionState> OnConnectionStateChanged { get; }

        /// <summary>
        /// <para>Returns client's current connection state.</para>
        /// <para>Initial connection state is <see cref="Model.ConnectionState.Disconnected"/>.</para>
        /// </summary>
        ConnectionState ConnectionState { get; }

        /// <summary>
        /// <para>Returns negotiated session timeout if client is connected, or <see cref="System.TimeSpan.Zero"/> otherwise.</para>
        /// </summary>
        TimeSpan SessionTimeout { get; }

        /// <summary>
        /// Returns client session id or <c>0</c> if not connected.
        /// </summary>
        long SessionId { get; }

        /// <summary>
        /// <para>Establishes connection with ZooKeeper cluster.</para>
        /// </summary>
        /// <returns><c>true</c> on successful connection, false otherwise.</returns>
        Task<bool> ConnectAsync();

        /// <summary>
        /// <para>Creates new node specified in given <paramref name="request" />.</para>
        /// <para>By default, all parent nodes will be created if they do not exist.</para>
        /// <para>Check returned <see cref="CreateResult"/> to see if operation was successful.</para>
        /// </summary>
        [ItemNotNull]
        Task<CreateResult> CreateAsync([NotNull] CreateRequest request);

        /// <summary>
        /// <para>Deletes the node specified in given <paramref name="request"/>.</para>
        /// <para>By default, all child nodes will be deleted if they exist.</para>
        /// <para>Check returned <see cref="DeleteResult"/> to see if operation was successful.</para>
        /// </summary>
        [ItemNotNull]
        Task<DeleteResult> DeleteAsync([NotNull] DeleteRequest request);

        /// <summary>
        /// <para>Sets the data for the node specified in given <paramref name="request" />.</para>
        /// <para>Check returned <see cref="SetDataResult"/> to see if operation was successful.</para>
        /// </summary>
        [ItemNotNull]
        Task<SetDataResult> SetDataAsync([NotNull] SetDataRequest request);

        /// <summary>
        /// <para>Checks whether the node specified in given <paramref name="request"/> exists.</para>
        /// <para>Check returned <see cref="ExistsResult"/> to see if operation was successful.</para>
        /// </summary>
        [ItemNotNull]
        Task<ExistsResult> ExistsAsync([NotNull] ExistsRequest request);

        /// <summary>
        /// <para>Returns the stat and child node names of the node specified given <paramref name="request" />.</para>
        /// <para>Check returned <see cref="GetChildrenResult"/> to see if operation was successful.</para>
        /// </summary>
        [ItemNotNull]
        Task<GetChildrenResult> GetChildrenAsync([NotNull] GetChildrenRequest request);

        /// <summary>
        /// <para>Returns the data and stat of the node specified in given <paramref name="request" />.</para>
        /// <para>Check returned <see cref="GetDataResult"/> to see if operation was successful.</para>
        /// </summary>
        [ItemNotNull]
        Task<GetDataResult> GetDataAsync([NotNull] GetDataRequest request);
    }
}