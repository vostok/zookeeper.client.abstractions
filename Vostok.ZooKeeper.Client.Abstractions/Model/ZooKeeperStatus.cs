using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents a status of arbitrary ZooKeeper operation.
    /// </summary>
    [PublicAPI]
    public enum ZooKeeperStatus
    {
        /// <summary>
        /// Operation has completed successfully.
        /// </summary>
        Ok,

        /// <summary>
        /// Operation has failed with an unclassified server/network error.
        /// </summary>
        UnknownError,

        /// <summary>
        /// Operation has failed due to invalid request.
        /// </summary>
        BadArguments,

        /// <summary>
        /// Node creation has failed due to parent node being ephemeral.
        /// </summary>
        ChildrenForEphemeralAreNotAllowed,

        /// <summary>
        /// Node creation has failed due to given node already existing.
        /// </summary>
        NodeAlreadyExists,

        /// <summary>
        /// Operation has failed due to given node not being found.
        /// </summary>
        NodeNotFound,

        /// <summary>
        /// Operation has failed due to inability to connect to ZooKeeper cluster.
        /// </summary>
        NotConnected,

        /// <summary>
        /// Operation has failed due to loss of connection with ZooKeeper cluster during execution.
        /// </summary>
        ConnectionLoss,

        /// <summary>
        /// Operation has failed due to client session expiry.
        /// </summary>
        SessionExpired,

        /// <summary>
        /// Operation has failed due to client session being moved to another server in cluster.
        /// </summary>
        SessionMoved,

        /// <summary>
        /// Operation has timed out.
        /// </summary>
        Timeout,

        /// <summary>
        /// Operation has failed due to mismatch of current node version and the one provided in request.
        /// </summary>
        VersionsMismatch,

        /// <summary>
        /// Node removal has failed due to given node having child nodes.
        /// </summary>
        NodeHasChildren,

        /// <summary>
        /// Write operation has been rejected due to read-only mode.
        /// </summary>
        NotReadonlyOperation,

        /// <summary>
        /// Client is not usable any more.
        /// </summary>
        Died
    }
}