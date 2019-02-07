namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Представляет статистику по конкретной ноде.
    /// </summary>
    public class Stat
    {
        public Stat(long czxid, long mzxid, long ctime, long mtime, int version, int cversion, int aversion, long ephemeralOwner, int dataLength, int numChildren, long pzxid)
        {
            Czxid = czxid;
            Mzxid = mzxid;
            Ctime = ctime;
            Mtime = mtime;
            Version = version;
            Cversion = cversion;
            Aversion = aversion;
            EphemeralOwner = ephemeralOwner;
            DataLength = dataLength;
            NumChildren = numChildren;
            Pzxid = pzxid;
        }

        /// <summary>
        /// Zxid операции, вызвавшей создание ноды.
        /// </summary>
        public long Czxid { get; private set; }

        /// <summary>
        /// Zxid операции, вызвавшей последнее изменение ноды.
        /// </summary>
        public long Mzxid { get; private set; }

        /// <summary>
        /// Время в мс. с эпохи, в которую произошло создание ноды.
        /// </summary>
        public long Ctime { get; private set; }

        /// <summary>
        /// Время в мс. с эпохи, в которую произошло последнее изменение ноды.
        /// </summary>
        public long Mtime { get; private set; }

        /// <summary>
        /// Количество изменений содержимого ноды.
        /// </summary>
        public int Version { get; private set; }

        /// <summary>
        /// Количество изменений состава дочерних нод.
        /// </summary>
        public int Cversion { get; private set; }

        /// <summary>
        /// Количество изменений ACL ноды.
        /// </summary>
        public int Aversion { get; private set; }

        /// <summary>
        /// Если нода эфемерная, возвращает Id сессии создавшего ее клиента. В противном случае возвращает 0.
        /// </summary>
        public long EphemeralOwner { get; private set; }

        /// <summary>
        /// Длина содержимого ноды.
        /// </summary>
        public int DataLength { get; private set; }

        /// <summary>
        /// Количетсво дочерних нод.
        /// </summary>
        public int NumChildren { get; private set; }
        public long Pzxid { get; private set; }

        #region Equality members
        protected bool Equals(Stat other)
        {
            return Czxid == other.Czxid
                && Mzxid == other.Mzxid
                && Ctime == other.Ctime
                && Mtime == other.Mtime
                && Version == other.Version
                && Cversion == other.Cversion
                && Aversion == other.Aversion
                && EphemeralOwner == other.EphemeralOwner
                && DataLength == other.DataLength
                && NumChildren == other.NumChildren
                && Pzxid == other.Pzxid;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Stat)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = Czxid.GetHashCode();
                hashCode = (hashCode * 397) ^ Mzxid.GetHashCode();
                hashCode = (hashCode * 397) ^ Ctime.GetHashCode();
                hashCode = (hashCode * 397) ^ Mtime.GetHashCode();
                hashCode = (hashCode * 397) ^ Version;
                hashCode = (hashCode * 397) ^ Cversion;
                hashCode = (hashCode * 397) ^ Aversion;
                hashCode = (hashCode * 397) ^ EphemeralOwner.GetHashCode();
                hashCode = (hashCode * 397) ^ DataLength;
                hashCode = (hashCode * 397) ^ NumChildren;
                hashCode = (hashCode * 397) ^ Pzxid.GetHashCode();
                return hashCode;
            }
        }
        #endregion
    }
}