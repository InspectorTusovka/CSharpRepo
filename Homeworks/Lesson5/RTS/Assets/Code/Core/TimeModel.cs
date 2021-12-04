using System;
using Code.Abstraction;
using UniRx;
using UnityEngine;
using Zenject;

namespace Code.Core
{
    public sealed class TimeModel : ITimeModel, ITickable
    {
        public IObservable<int> GameTime => _gameTime.Select(f => (int) f);
        private readonly ReactiveProperty<float> _gameTime = new ReactiveProperty<float>();

        public void Tick()
        {
            _gameTime.Value += Time.deltaTime;
        }
    }
}