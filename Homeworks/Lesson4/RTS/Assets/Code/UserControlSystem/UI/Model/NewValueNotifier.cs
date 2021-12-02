using System;
using Code.Utilities;

namespace Code.UserControlSystem.UI.Model
{
    public class NewValueNotifier<TAwaited> : AwaiterBase<TAwaited>
    {
        private readonly ValueBase<TAwaited> _valueBase;
        private TAwaited _result;

        public NewValueNotifier(ValueBase<TAwaited> valueBase)
        {
            _valueBase = valueBase;
            _valueBase.OnNewValue += ONNewValue;
        }

        private void ONNewValue(TAwaited obj)
        {
            _valueBase.OnNewValue -= ONNewValue;
            _result = obj;
            _isCompleted = true;
            _continuation?.Invoke();
        }
        public override TAwaited GetResult() => _result;
    }
}