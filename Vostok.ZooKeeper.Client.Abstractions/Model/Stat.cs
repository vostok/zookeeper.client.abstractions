using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents node statistic
    /// </summary>
    [PublicAPI]
    public class Stat
    {
        /// <inheritdoc />
        public Stat(long createdZxid, long modifiedZxid, long modifiedChildrenZxid, long createdTime, long modifiedtime, int version, int childrenVersion, int aclVersion, long ephemeralOwner, int dataLength, int numberOfChildren)
        {
            CreatedZxid = createdZxid;
            ModifiedZxid = modifiedZxid;
            ModifiedChildrenZxid = modifiedChildrenZxid;
            CreatedTime = createdTime;
            Modifiedtime = modifiedtime;
            Version = version;
            ChildrenVersion = childrenVersion;
            AclVersion = aclVersion;
            EphemeralOwner = ephemeralOwner;
            DataLength = dataLength;
            NumberOfChildren = numberOfChildren;
        }

        /// <summary>
        /// Returns the zxid of the change that caused this znode to be created.
        /// </summary>
        public long CreatedZxid { get; }

        /// <summary>
        /// Returns the zxid of the change that last modified this znode.
        /// </summary>
        public long ModifiedZxid { get; }

        /// <summary>
        /// Returns the zxid of the change that last modified children of this znode.
        /// </summary>
        public long ModifiedChildrenZxid { get; }

        /// <summary>
        /// Returns the time in milliseconds from epoch when this znode was created.
        /// </summary>
        public long CreatedTime { get; }

        /// <summary>
        /// Returns the time in milliseconds from epoch when this znode was last modified.
        /// </summary>
        public long Modifiedtime { get; }

        /// <summary>
        /// Returns the number of changes to the data of this znode.
        /// </summary>
        public int Version { get; }

        /// <summary>
        /// Returns the number of changes to the children of this znode.
        /// </summary>
        public int ChildrenVersion { get; }

        /// <summary>
        /// Returns the number of changes to the ACL of this znode.
        /// </summary>
        public int AclVersion { get; }

        /// <summary>
        /// Returns the session id of the owner of this znode if the znode is an ephemeral node.
        /// If it is not an ephemeral node, it will be zero.
        /// </summary>
        public long EphemeralOwner { get; }

        /// <summary>
        /// Returns the length of the data field of this znode.
        /// </summary>
        public int DataLength { get; }

        /// <summary>
        /// Returns the number of children of this znode.
        /// </summary>
        public int NumberOfChildren { get; }

        #region Equality members

        /// <summary>
        /// Compares two <see cref="Stat"/> instances.
        /// </summary>
        public bool Equals(Stat other)
        {
            return CreatedZxid == other.CreatedZxid && ModifiedZxid == other.ModifiedZxid && ModifiedChildrenZxid == other.ModifiedChildrenZxid && CreatedTime == other.CreatedTime && Modifiedtime == other.Modifiedtime && Version == other.Version && ChildrenVersion == other.ChildrenVersion && AclVersion == other.AclVersion && EphemeralOwner == other.EphemeralOwner && DataLength == other.DataLength && NumberOfChildren == other.NumberOfChildren;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((Stat)obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = CreatedZxid.GetHashCode();
                hashCode = (hashCode * 397) ^ ModifiedZxid.GetHashCode();
                hashCode = (hashCode * 397) ^ ModifiedChildrenZxid.GetHashCode();
                hashCode = (hashCode * 397) ^ CreatedTime.GetHashCode();
                hashCode = (hashCode * 397) ^ Modifiedtime.GetHashCode();
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