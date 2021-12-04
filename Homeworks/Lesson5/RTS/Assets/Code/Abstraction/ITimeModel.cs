using System;

namespace Code.Abstraction
{
    public interface ITimeModel
    {
        IObservable<int> GameTime { get; }
    }
}