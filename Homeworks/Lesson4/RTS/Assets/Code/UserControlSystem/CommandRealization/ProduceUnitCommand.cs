using Code.Abstraction;
using Code.Utilities;
using UnityEngine;

namespace Code.UserControlSystem.CommandRealization
{
    public class ProduceUnitCommand : IProduceUnitCommand
    {
        public GameObject UnitPrefab => _unitPrefab;
        [InjectAssets("WeakUnit")] private GameObject _unitPrefab;
    }
}