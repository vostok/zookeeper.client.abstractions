using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Представляет интерфейс для клиентских обработчиков событий, на которые можно подписаться при операциях чтения.
    /// </summary>
    [PublicAPI]
    public interface IWatcher
    {
        void ProcessEvent(EventType type, string path);
    }
}