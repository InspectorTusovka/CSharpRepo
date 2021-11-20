using Code.Abstraction;
using Code.UserControlSystem.CommandRealization;
using Code.UserControlSystem.UI.Model;
using Code.UserControlSystem.UI.View;
using Code.Utilities;
using System.Collections.Generic;
using UnityEngine;

public class CommandButtonsPresenter : MonoBehaviour
{
    [SerializeField] private SelectableValue _selectable;
    [SerializeField] private CommandButtonsView _view;
    [SerializeField] AssetsContext _context;

    private ISelectable _currentSelectable;

    private void Start()
    {
        _selectable.OnSelected += onSelected;
        onSelected(_selectable.CurrentValue);

        _view.OnClick += onButtonClick;
    }

    private void onSelected(ISelectable selectable)
    {
        if (_currentSelectable == selectable)
            return;
        _currentSelectable = selectable;

        _view.Clear();

        if (selectable != null)
        {
            var commandExecutors = new List<ICommandExecutor>();
            commandExecutors.AddRange((selectable as Component).GetComponents<ICommandExecutor>());
            _view.MakeLayout(commandExecutors);
        }
    }

    private void onButtonClick(ICommandExecutor executor)
    {
        if (executor is CommandExecutor<IProduceUnitCommand>)
        {
            var unitProducer = executor as CommandExecutor<IProduceUnitCommand>;
            if (unitProducer != null)
            {
                unitProducer.ExecuteSpecificCommand(_context.Inject(new ProduceUnitCommandHeir()));
                return;
            }
        }
        else if (executor is CommandExecutor<IMoveCommand>)
        {
            var moveUnit = executor as CommandExecutor<IMoveCommand>;
            if (moveUnit != null)
            {
                moveUnit.ExecuteSpecificCommand(_context.Inject(new MoveCommand()));
                return;
            }
        }
        else if (executor is CommandExecutor<IPatrolCommand>)
        {
            var moveUnit = executor as CommandExecutor<IPatrolCommand>;
            if (moveUnit != null)
            {
                moveUnit.ExecuteSpecificCommand(_context.Inject(new PatrolCommand()));
                return;
            }
        }
        else if (executor is CommandExecutor<IHoldCommand>)
        {
            var moveUnit = executor as CommandExecutor<IHoldCommand>;
            if (moveUnit != null)
            {
                moveUnit.ExecuteSpecificCommand(_context.Inject(new HoldCommand()));
                return;
            }
        }
        else if (executor is CommandExecutor<IAttackCommand>)
        {
            var moveUnit = executor as CommandExecutor<IAttackCommand>;
            if (moveUnit != null)
            {
                moveUnit.ExecuteSpecificCommand(_context.Inject(new AttackCommand()));
                return;
            }
        }
    }
}
