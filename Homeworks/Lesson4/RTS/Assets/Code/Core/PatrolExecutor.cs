using UnityEngine;
using Code.Abstraction;

namespace Code.Core
{
    public class PatrolExecutor : CommandExecutor<IPatrolCommand>
    {
        //[SerializeField] private UnitMovementStop _stop;
        //private bool _isPatrolling = true;
        public override async void ExecuteSpecificCommand(IPatrolCommand command)
        {
            Debug.Log($"{name} patrol area between {transform.position} and {command.TargetPosition}");

            #region Infinite patrolling
/*var agent = GetComponentInChildren<NavMeshAgent>();
            agent.destination = command.TargetPosition;
            
            var waypoints = new Vector3[2] {GetComponent<Transform>().position, command.TargetPosition};
            
            int index = 0;
            
            while (true)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    agent.destination = waypoints[index];
                    if (index == waypoints.Length - 1) 
                        index = 0;
                    else
                        ++index;
                }

                await _stop;
                
            }*/
            

            #endregion
        }
    }

}
