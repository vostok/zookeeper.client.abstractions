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
        private const char Slash = '/';

        /// <summary>
        /// <para>Splits node <paramref name="path"/> to segments.</para>
        /// <para>Produces empty name at the end, if path ends with slash.</para>
        /// </summary>
        public static string[] Split(string path)
        {
            return path.TrimStart(Slash).Split(Slash);
        }

        /// <summary>
        /// Combines path <paramref name="segments"/>.
        /// </summary>
        public static string Combine(params string[] segments)
        {
            var result = new StringBuilder();
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
    }
}