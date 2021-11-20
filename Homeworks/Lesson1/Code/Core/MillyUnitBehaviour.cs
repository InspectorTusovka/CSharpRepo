using Code.Abstraction;
using UnityEngine;

namespace Code.Core
{
    public class MillyUnitBehaviour : MonoBehaviour, ISelectable
    {
        private float _maxHealth = 150;
        private float _health = 150;
        [SerializeField] private Sprite _icon;
        [SerializeField] Component _outline;

        public float maxHealth => _maxHealth;
        public float health => _health;
        public Sprite Icon => _icon;
        public Component outline => _outline;
    }

}
