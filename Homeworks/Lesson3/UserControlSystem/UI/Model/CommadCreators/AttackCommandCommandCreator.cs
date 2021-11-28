using System;
using Code.Abstraction;
using Code.UserControlSystem.CommandRealization;
using Code.Utilities;
using UnityEngine;
using Zenject;

namespace Code.UserControlSystem.UI.Model.CommandCreators
{
    public  class  AttackCommandCommandCreator : CommandCreator<IAttackCommand>
    {
        [Inject] private AssetsContext _context;

        private Action<IAttackCommand> _creationCallback;

        [Inject]
        private void Init(AttackableValue attackClicks)
        {
            attackClicks.OnAttack += onAttack;
        }

        private void onAttack(IAttackable attackClick)
        {
            _creationCallback?.Invoke(_context.Inject(new AttackCommand(attackClick)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
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