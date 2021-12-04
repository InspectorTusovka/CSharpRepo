using System;
using System.Threading;
using Code.Abstraction;
using Code.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace Code.Core
{
    public class MoveExecutor : CommandExecutor<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;

        [SerializeField] private HoldExecutor _holdExecutor;
        //For Animator:: [SerializeField] private Animator _animator;
        //private static readonly int Walk = Animator.StringToHash("Walk");
        //private static readonly int Idle = Animator.StringToHash("Idle");
        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponentInChildren<NavMeshAgent>().destination = command.Target;
            //_animator.SetTrigger(Walk);
            _holdExecutor.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop
                    .WithCancellation(_holdExecutor.CancellationTokenSource.Token);
            }
            catch
            {
                GetComponentInChildren<NavMeshAgent>().isStopped = true;
                GetComponentInChildren<NavMeshAgent>().ResetPath();
            }

            _holdExecutor.CancellationTokenSource = null;
            //_animator.SetTrigger(Idle);
        }
    }

}
