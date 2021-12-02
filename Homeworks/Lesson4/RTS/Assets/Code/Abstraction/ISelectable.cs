using UnityEngine;

namespace Code.Abstraction
{
    public interface ISelectable
    {
        float maxHealth { get; }
        float health { get; }
        Sprite Icon { get; }
        Component outline { get; }
    }
}