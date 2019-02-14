using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    // CR(iloktionov): Implement AdHocWatcher supplied with user-provided Action.

    /// <summary>
    /// Представляет интерфейс для клиентских обработчиков событий, на которые можно подписаться при операциях чтения.
    /// </summary>
    [PublicAPI]
    public interface INodeWatcher
    {
        void ProcessEvent(NodeChangedEventType type, string path);
    }
}