using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    /// <summary>
    /// Represents ZooKeeper exists node request.
    /// </summary>
    [PublicAPI]
    public class ExistsRequest : GetRequest
    {
        public ExistsRequest([NotNull] string path)
            : base(path)
        {
        }

        public override string ToString() => $"EXISTS {base.ToString()}";
    }
}