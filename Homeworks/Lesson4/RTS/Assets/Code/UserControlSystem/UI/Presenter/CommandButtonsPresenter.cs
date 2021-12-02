using System.Collections.Generic;
using Code.Abstraction;
using Code.UserControlSystem.UI.Model;
using Code.UserControlSystem.UI.View;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UI.Presenter
{
    public class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;

        [Inject] private CommandButtonsModel _model;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;

            _selectable.OnNewValue += OnSelected;
            OnSelected(_selectable.Currentvalue);
        }

        private void OnSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
                return;

            if (_currentSelectable != null) 
                _model.OnSelectionChanged();
            _currentSelectable = selectable;
            
            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponents<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }
    }
}
        