using JetBrains.Annotations;
using Vostok.ZooKeeper.Client.Abstractions.Model.Request;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents ZooKeeper operation status.
    /// </summary>
    [PublicAPI]
    public enum ZooKeeperStatus
    {
        /// <summary>
        /// Operation finished successfully.
        /// </summary>
        Ok,

        /// <summary>
        /// Operation finished with some network/cluster error.
        /// </summary>
        UnknownError,

        /// <summary>
        /// Invalid <see cref="ZooKeeperRequest"/> was given.
        /// </summary>
        BadArguments,

        /// <summary>
        /// Creating children inside ephemeral nodes are not allowed.
        /// </summary>
        ChildrenForEphemeralsAreNotAllowed,

        /// <summary>
        /// Creating already existing node are not allowed.
        /// </summary>
        NodeAlreadyExists,

        /// <summary>
        /// Node not found.
        /// </summary>
        NodeNotFound,

        /// <summary>
        /// Client is not curently connected to ZooKeeper cluster.
        /// </summary>
        NotConnected,

        /// <summary>
        /// Connection lost during operation execution.
        /// </summary>
        ConnectionLoss,

        /// <summary>
        /// Session expired during operation execution.
        /// </summary>
        SessionExpired,

        /// <summary>
        /// Session moved to another server, so operation is ignored.
        /// </summary>
        SessionMoved,

        /// <summary>
        /// Operation timed out.
        /// </summary>
        Timeout,

        /// <summary>
        /// Mismatch of current and provided node versions.
        /// </summary>
        VersionsMismatch,

        /// <summary>
        /// Node has children.
        /// </summary>
        NodeHasChildren,

        /// <summary>
        /// Write operation rejected in read-only mode.
        /// </summary>
        NotReadonlyOperation
    }
}