using Code.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UserControlSystem.UI.View
{
    public class CommandButtonsView : MonoBehaviour
    {
        public event Action<ICommandExecutor> OnClick;

        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _holdButton;
        [SerializeField] private GameObject _produceButton;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;

        private void Start()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>();
            _buttonsByExecutorType
                .Add(typeof(CommandExecutor<IAttackCommand>), _attackButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutor<IMoveCommand>), _moveButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutor<IPatrolCommand>), _patrolButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutor<IHoldCommand>), _holdButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutor<IProduceUnitCommand>), _produceButton);
        }

        public void MakeLayout(IEnumerable<ICommandExecutor> commandExecutors)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                var buttonGameObject = _buttonsByExecutorType
                    .First(type => type.Key.IsInstanceOfType(currentExecutor))
                    .Value;
                buttonGameObject.SetActive(true);
                var button = buttonGameObject.GetComponent<Button>();
                button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
            }
        }

        public void Clear()
        {
            foreach (var removable in _buttonsByExecutorType)
            {
                removable.Value.GetComponent<Button>().onClick.RemoveAllListeners();
                removable.Value.SetActive(false);
            }
        }

        public void UnblockAllInteractions() => SetInteractable(true);

        private void SetInteractable(bool value)
        {
            _attackButton.GetComponent<Selectable>().interactable = value;
            _moveButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _produceButton.GetComponent<Selectable>().interactable = value;
            _holdButton.GetComponent<Selectable>().interactable = value;
        }

        public void BlockInteractions(ICommandExecutor executor)
        {
            UnblockAllInteractions();
            GetButtonGameObjectByType(executor.GetType())
                .GetComponent<Selectable>().interactable = false;
        }

        private GameObject GetButtonGameObjectByType(Type executorInstanceType)
        {
            return _buttonsByExecutorType
                .First(type => type.Key.IsAssignableFrom(executorInstanceType))
                .Value;
        }
    }
}
