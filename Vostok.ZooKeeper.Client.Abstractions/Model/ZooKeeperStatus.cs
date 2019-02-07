namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    public enum ZooKeeperStatus
    {
        /// <summary>
        /// Все хорошо!
        /// </summary>
        Ok = 0,

        RuntimeInconsistency = -2,

        /// <summary>
        /// Была обнаружена неконсистетность данных.
        /// </summary>
        DataInconsistency = -3,

        /// <summary>
        /// Соединение с сервером было потеряно или не было установлено за отведенное время.
        /// </summary>
        ConnectionLoss = -4,

        /// <summary>
        /// Ошибка при маршаллинге данных.
        /// </summary>
        MarshallingError = -5,

        /// <summary>
        /// Операция не реализована на сервере.
        /// </summary>
        Unimplemented = -6,

        /// <summary>
        /// Операция не могла быть выполнена за отведенное время.
        /// </summary>
        OperationTimeout = -7,

        /// <summary>
        /// В клиент были переданы некорректные аргументы.
        /// </summary>
        BadArguments = -8,

        /// <summary>
        /// Эзкемпляр клиента не был запущен или был закрыт.
        /// </summary>
        ClientNotRunning = -98,

        /// <summary>
        /// Неизвестная клиентская ошибка.
        /// </summary>
        UnclassifiedError = -99,

        /// <summary>
        /// Нода с указанным путем не существует.
        /// </summary>
        NoNode = -101,

        /// <summary>
        /// Аутентификация не произошла.
        /// </summary>
        NoAuth = -102,

        /// <summary>
        /// Указанная версия не совпала с актуальной.
        /// </summary>
        BadVersion = -103,

        /// <summary>
        /// Попытка создать дочернюю ноду для эфемерной.
        /// </summary>
        NoChildrenForEphemerals = -108,

        /// <summary>
        /// Попытка создать уже существующую ноду.
        /// </summary>
        NodeExists = -110,

        /// <summary>
        /// Попытка удалить ноду, имеющую дочерние.
        /// </summary>
        NotEmpty = -111,

        /// <summary>
        /// Клиентская сессия истекла.
        /// </summary>
        SessionExpired = -112,

        InvalidCallback = -113,

        InvalidACL = -114,

        /// <summary>
        /// Отказано в аутентификации.
        /// </summary>
        AuthFailed = -115,

        /// <summary>
        /// Сессия переехала на другой сервер, операция проигнорирована.
        /// </summary>
        SessionMoved = -118,

        /// <summary>
        /// Попытка записи при соединении с сервером в режиме чтения.
        /// </summary>
        NotReadonly = -119,
    }

}