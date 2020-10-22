using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Authentication
{
    /// <summary>
    /// Represents zookeeper permissions.
    /// </summary>
    [Flags]
    [PublicAPI]
    public enum AclPermissions
    {
        /// <summary>
        /// Permission to get data from a node and list its children.
        /// </summary>
        Read = 1,

        /// <summary>
        /// Permission to set data for a node.
        /// </summary>
        Write = 2,

        /// <summary>
        /// Permission to create a child node.
        /// </summary>
        Create = 4,

        /// <summary>
        /// Permission to delete a child node.
        /// </summary>
        Delete = 8,

        /// <summary>
        /// Permission to set permissions.
        /// </summary>
        Admin = 16,

        /// <summary>
        /// Permission to get data from a node and list its children.
        /// </summary>
        All = Admin | Delete | Create | Write | Read
    }
}