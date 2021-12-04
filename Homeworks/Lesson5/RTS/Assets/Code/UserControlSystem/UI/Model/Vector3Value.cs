using UnityEngine;

namespace Code.UserControlSystem.UI.Model
{
    [CreateAssetMenu(fileName = nameof(Vector3Value), menuName = "RTS/"+nameof(Vector3Value),order = 0)]
    public class Vector3Value : StatelessValueBase<Vector3>{}
}