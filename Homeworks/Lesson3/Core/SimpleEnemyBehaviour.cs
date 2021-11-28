using System;
using System.Collections;
using Code.Abstraction;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Core
{
    public class SimpleEnemyBehaviour : MonoBehaviour, IAttackable, ISelectable
    {
        public float maxHealth => _health;
        public float health => _health;
        public Sprite Icon => _icon;
        public Component outline => _outline;
        
        private float _health = 200;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Component _outline;
    }
}