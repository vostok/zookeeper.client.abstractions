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
        /// Splits <paramref name="path"/> to segments.
        /// </summary>
        public static string[] Split(string path)
        {
            return path.Trim('/').Split('/');
        }

        /// <summary>
        /// Combines path <paramref name="segments"/>.
        /// </summary>
        public static string Combine(string[] segments)
        {
            var result = new StringBuilder();
            for (var i = 0; i < segments.Length; i++)
            {
                if (string.IsNullOrEmpty(segments[i]))
                    continue;

                result.Append("/");
                result.Append(
                    i + 1 != segments.Length
                        ? segments[i].Trim('/')
                        : segments[i].TrimStart('/'));
            }

            return result.ToString();
        }
    }
}