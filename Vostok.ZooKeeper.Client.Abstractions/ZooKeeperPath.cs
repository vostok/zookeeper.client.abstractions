using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions
{
    /// <summary>
    /// ZooKeeper path helper.
    /// </summary>
    [PublicAPI]
    public static class ZooKeeperPath
    {
        /// <summary>
        /// Root path in ZooKeeper nodes tree.
        /// </summary>
        public const string Root = "/";

        private const char Slash = '/';

        /// <summary>
        /// <para>Splits given node <paramref name="path"/> to segments.</para>
        /// <para>Produces an empty name at the end if path ends with slash.</para>
        /// </summary>
        [NotNull]
        public static string[] Split([NotNull] string path)
            => path.TrimStart(Slash).Split(Slash);

        /// <summary>
        /// Combines given <paramref name="basePath"/> and <paramref name="relativePath"/> into a new path.
        /// </summary>
        [NotNull]
        public static string Combine([NotNull] string basePath, [NotNull] string relativePath)
            => $"{basePath.TrimEnd(Slash)}/{relativePath.TrimStart(Slash)}";

        /// <summary>
        /// Combines given <paramref name="segments"/> into a path.
        /// </summary>
        [NotNull]
        public static string Combine([NotNull] params string[] segments)
        {
            var result = new StringBuilder(segments.Sum(s => s.Length) + segments.Length);

            for (var i = 0; i < segments.Length; i++)
            {
                if (result.Length == 0 || result[result.Length - 1] != Slash)
                    result.Append(Slash);

                result.Append(
                    i + 1 != segments.Length
                        ? segments[i].Trim(Slash)
                        : segments[i].TrimStart(Slash));
            }

            return result.ToString();
        }

        /// <summary>
        /// <para>Returns the path to to the parent of the node located by given <paramref name="path"/>.</para>
        /// <para>May return <c>null</c> if presented with a root node path.</para>
        /// </summary>
        [CanBeNull]
        public static string GetParentPath([NotNull] string path)
        {
            var lastSlashIndex = path.LastIndexOf(Slash);
            if (lastSlashIndex < 0)
                return null;

            if (lastSlashIndex == 0)
                return path == Root ? null : Root;

            return path.Substring(0, lastSlashIndex);
        }
    }
}