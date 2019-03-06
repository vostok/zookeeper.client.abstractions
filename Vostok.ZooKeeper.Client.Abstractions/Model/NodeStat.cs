using System;
using JetBrains.Annotations;
using Vostok.Commons.Time;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents node statistic.
    /// </summary>
    [PublicAPI]
    public class NodeStat
    {
        /// <inheritdoc />
        public NodeStat(long createdZxId, long modifiedZxId, long modifiedChildrenZxId, long createdTimeMs, long modifiedTimeMs, int version, int childrenVersion, int aclVersion, long ephemeralOwner, int dataLength, int numberOfChildren)
        {
            CreatedZxId = createdZxId;
            ModifiedZxId = modifiedZxId;
            ModifiedChildrenZxId = modifiedChildrenZxId;
            CreatedTimeMs = createdTimeMs;
            ModifiedTimeMs = modifiedTimeMs;
            Version = version;
            ChildrenVersion = childrenVersion;
            AclVersion = aclVersion;
            EphemeralOwner = ephemeralOwner;
            DataLength = dataLength;
            NumberOfChildren = numberOfChildren;
        }

        /// <summary>
        /// Returns the ZxId of the change that caused this node to be created.
        /// </summary>
        public long CreatedZxId { get; }

        /// <summary>
        /// Returns the ZxId of the change that last modified this node.
        /// </summary>
        public long ModifiedZxId { get; }

        /// <summary>
        /// Returns the ZxId of the change that last modified children of this node.
        /// </summary>
        public long ModifiedChildrenZxId { get; }

        /// <summary>
        /// Returns the time in milliseconds from epoch when this node was created.
        /// </summary>
        public long CreatedTimeMs { get; }

        /// <summary>
        /// Returns the time when this node was created.
        /// </summary>
        public DateTimeOffset CreatedTime => EpochHelper.FromUnixTimeMilliseconds(CreatedTimeMs);

        /// <summary>
        /// Returns the time in milliseconds from epoch when this node was last modified.
        /// </summary>
        public long ModifiedTimeMs { get; }

        /// <summary>
        /// Returns the time when this node was created.
        /// </summary>
        public DateTimeOffset ModifiedTime => EpochHelper.FromUnixTimeMilliseconds(ModifiedTimeMs);

        /// <summary>
        /// Returns the number of changes to the data of this node.
        /// </summary>
        public int Version { get; }

        /// <summary>
        /// Returns the number of changes to the children of this node.
        /// </summary>
        public int ChildrenVersion { get; }

        /// <summary>
        /// Returns the number of changes to the ACL of this node.
        /// </summary>
        public int AclVersion { get; }

        /// <summary>
        /// Returns the session id of the owner of this node if the node is an ephemeral node.
        /// If it is not an ephemeral node, it will be zero.
        /// </summary>
        public long EphemeralOwner { get; }

        /// <summary>
        /// Returns the length of the data field of this node.
        /// </summary>
        public int DataLength { get; }

        /// <summary>
        /// Returns the number of children of this node.
        /// </summary>
        public int NumberOfChildren { get; }

        #region Equality members

        /// <summary>
        /// Compares two <see cref="NodeStat"/> instances.
        /// </summary>
        public bool Equals(NodeStat other)
        {
            return CreatedZxId == other.CreatedZxId && ModifiedZxId == other.ModifiedZxId && ModifiedChildrenZxId == other.ModifiedChildrenZxId && CreatedTimeMs == other.CreatedTimeMs && ModifiedTimeMs == other.ModifiedTimeMs && Version == other.Version && ChildrenVersion == other.ChildrenVersion && AclVersion == other.AclVersion && EphemeralOwner == other.EphemeralOwner && DataLength == other.DataLength && NumberOfChildren == other.NumberOfChildren;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;
            return Equals((NodeStat)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CreatedZxId.GetHashCode();
                hashCode = (hashCode * 397) ^ ModifiedZxId.GetHashCode();
                hashCode = (hashCode * 397) ^ ModifiedChildrenZxId.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedTimeMs.GetHashCode();
                hashCode = (hashCode * 397) ^ ModifiedTimeMs.GetHashCode();
                hashCode = (hashCode * 397) ^ Version;
                hashCode = (hashCode * 397) ^ ChildrenVersion;
                hashCode = (hashCode * 397) ^ AclVersion;
                hashCode = (hashCode * 397) ^ EphemeralOwner.GetHashCode();
                hashCode = (hashCode * 397) ^ DataLength;
                hashCode = (hashCode * 397) ^ NumberOfChildren;
                return hashCode;
            }
        }

        #endregion
    }
}