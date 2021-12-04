using System.Threading;
using Code.Abstraction;

namespace Code.Core
{
    public class HoldExecutor : CommandExecutor<IHoldCommand>
    {
        public CancellationTokenSource CancellationTokenSource { get; set; }
        public override void ExecuteSpecificCommand(IHoldCommand command)
        {
            CancellationTokenSource?.Cancel();
        }
    }

}