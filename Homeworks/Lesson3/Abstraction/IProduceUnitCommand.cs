using UnityEngine;
namespace Code.Abstraction
{
    public interface IProduceUnitCommand : ICommand
    {
        GameObject UnitPrefab { get; }
    }
}