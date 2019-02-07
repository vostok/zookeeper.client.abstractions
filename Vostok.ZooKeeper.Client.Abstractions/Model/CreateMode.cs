namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    public enum CreateMode
    {
        /// <summary>
        /// <para>Нода сохраняется после истечения клиентской сессии.</para>
        /// </summary>
        Persistent = 0,

        /// <summary>
        /// <para>Нода будет автоматически удалена при истечении клиентской сессии.</para>
        /// </summary>
        Ephemeral = 1,

        /// <summary>
        /// <para>Нода сохраняется после истечения клиентской сессии.</para>
        /// <para>К имени ноды будет добавлен 10-значный цифровой монотонно возрастающий суффикс, уникальный в пределах родительской ноды.</para>
        /// </summary>
        PersistentSequential = 2,

        /// <summary>
        /// <para>Нода будет автоматически удалена при истечении клиентской сессии.</para>
        /// <para>К имени ноды будет добавлен 10-значный монотонно возрастающий суффикс, уникальный в пределах родительской ноды.</para>
        /// </summary>
        EphemeralSequential = 3
    }
}