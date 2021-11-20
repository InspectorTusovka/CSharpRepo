using Code.Abstraction;
using Code.UserControlSystem.UI.Model;
using UnityEngine;
using UnityEngine.EventSystems;


namespace Code.UserControlSystem.UI.Presenter
{
    public sealed class MouseInteractionsPresenter : MonoBehaviour
    {
        [SerializeField] Camera _mainCamera;
        [SerializeField] private SelectableValue _selectedObj;
        [SerializeField] private EventSystem _eventSystem;

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0))
                return;

            if (_eventSystem.IsPointerOverGameObject())
                return;

            var hits = Physics.RaycastAll(_mainCamera.ScreenPointToRay(Input.mousePosition));
            if (hits.Length == 0)
                return;

            foreach (var selectable in hits)
            {
                if (!selectable.collider.TryGetComponent(out ISelectable component))
                {
                    _selectedObj.SetValue(null);
                    return;
                }

                else
                {
                    _selectedObj.SetValue(component);
                    return;
                }

            }
        }
    }

}
