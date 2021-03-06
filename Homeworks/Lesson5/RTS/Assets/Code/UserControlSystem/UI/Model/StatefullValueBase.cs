using System;
using UniRx;

namespace Code.UserControlSystem.UI.Model
{
    public abstract class StatefullValueBase<T> : ValueBase<T>, IObservable<T>
    {
        private ReactiveProperty<T> _innerDataSource = new ReactiveProperty<T>();
        public override void SetValue(T value)
        {
            base.SetValue(value);
            _innerDataSource.Value = value;
        }

        public IDisposable Subscribe(IObserver<T> observer)
            => _innerDataSource.Subscribe(observer);
    }
}