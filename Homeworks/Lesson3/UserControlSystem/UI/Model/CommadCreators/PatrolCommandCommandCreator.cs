using System;
using Code.Abstraction;
using Code.UserControlSystem.CommandRealization;
using Code.Utilities;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public  class PatrolCommandCommandCreator : CommandCreator<IPatrolCommand>
    {
        [Inject] private AssetsContext _context;

        private Action<IPatrolCommand> _creationCallback;

        [Inject]
        private void Init(Vector3Value groundClicks)
        {
            groundClicks.OnNewValue += onNewValue;
        }

        private void onNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new PatrolCommand(groundClick)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }
}