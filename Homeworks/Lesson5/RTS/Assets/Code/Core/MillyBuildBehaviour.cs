using Code.Abstraction;
using UnityEngine;

namespace Code.Core
{
    public class MillyBuildBehaviour : CommandExecutor<IProduceUnitCommand>, ISelectable, IAttackable
    {
        private float _maxHealth = 2000;
        private float _currentHealth = 2000;
        [SerializeField] Sprite _icon;
        [SerializeField] private Transform _unitsParent;
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private Component _outline;
        public float maxHealth => _maxHealth;
        public float health => _currentHealth;
        public Sprite Icon => _icon;
        public Component outline => _outline;

        public override void ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            Instantiate(command.UnitPrefab, spawnPoint.position, Quaternion.identity, _unitsParent);
        }
    }
}