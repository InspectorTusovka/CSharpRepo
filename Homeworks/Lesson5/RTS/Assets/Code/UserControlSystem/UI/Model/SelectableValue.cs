using Code.Abstraction;
using UnityEngine;

namespace Code.UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "RTS/" + nameof(SelectableValue))]
    public sealed class SelectableValue : StatefullValueBase<ISelectable>
    { }
}