using Code.Abstraction;
using UnityEngine;

namespace Code.Core
{
    public class HoldExecutor : CommandExecutor<IHoldCommand>
    {
        public override void ExecuteSpecificCommand(IHoldCommand command)
        {
            Debug.Log($"Hold position!");
        }
    }

}