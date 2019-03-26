using System;
using JetBrains.Annotations;

namespace Vostok.ZooKeeper.Client.Abstractions.Model
{
    /// <summary>
    /// Represents a <see cref="IZooKeeperClient"/> <see cref="ConnectionState"/> observer that uses an external delegate to process new states or completion.
    /// </summary>
    [PublicAPI]
    public class AdHocConnectionStateObserver : IObserver<ConnectionState>
    {
        [CanBeNull]
        private readonly Action<ConnectionState> onNext;

        [CanBeNull]
        private readonly Action onCompleted;

        public AdHocConnectionStateObserver([CanBeNull] Action<ConnectionState> onNext, [CanBeNull] Action onCompleted)
        {
            this.onNext = onNext;
            this.onCompleted = onCompleted;
        }

        public void OnCompleted()
        {
            onCompleted?.Invoke();
        }

        public void OnNext(ConnectionState value)
        {
            onNext?.Invoke(value);
        }

        public void OnError(Exception error)
        {
        }
    }
}