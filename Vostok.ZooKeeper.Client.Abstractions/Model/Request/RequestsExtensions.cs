using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model.Request
{
    [PublicAPI]
    public static class RequestsExtensions
    {
        public static DeleteRequest WithPath([NotNull] this DeleteRequest request, [NotNull] string newPath) =>
            new DeleteRequest(newPath) {DeleteChildrenIfNeeded = request.DeleteChildrenIfNeeded, Version = request.Version};

        public static CreateRequest WithPath([NotNull] this CreateRequest request, [NotNull] string newPath) =>
            new CreateRequest(newPath, request.CreateMode) {CreateParentsIfNeeded = request.CreateParentsIfNeeded, Data = request.Data};
    }
}