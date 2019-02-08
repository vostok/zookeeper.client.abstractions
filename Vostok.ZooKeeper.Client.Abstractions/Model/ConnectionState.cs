namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    // CR(iloktionov): Add a value to represent initial state before first connect.

    public enum ConnectionState
    {
        /// <summary>
        /// Генерируется при первом успешном соединении с сервером (один раз за время жизни объекта <see cref="ZooKeeperClient"/>.)
        /// </summary>
        Connected = 0,

        /// <summary>
        /// Соединение, возможно, потеряно. Статус сессии неизвестен. Лидерство и блокировки после этого нельзя безопасно считать захваченными.
        /// </summary>
        Suspended = 1,

        /// <summary>
        /// Потерянное соединение было восстановлено. Может возникать после <see cref="Suspended"/>, <see cref="Lost"/>, <see cref="Readonly"/>.
        /// Тем не менее, последовательность <see cref="Lost"/> --> <see cref="Reconnected"/> означает, что была установлена новая сессия.
        /// </summary>
        Reconnected = 2,

        /// <summary>
        /// Соединение точно потеряно. Эфемерные ноды потеряны, требуется перезапуск локов и лидерства.
        /// </summary>
        Lost = 3,

        /// <summary>
        /// Соединение работает в режиме чтения (сервер потерял кворум). Операции записи недоступны.
        /// </summary>
        Readonly = 4,
    }
}