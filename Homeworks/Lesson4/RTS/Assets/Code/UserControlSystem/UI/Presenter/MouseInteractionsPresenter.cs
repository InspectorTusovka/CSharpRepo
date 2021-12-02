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

        [SerializeField] private AttackableValue _attackRMB;
        [SerializeField] private Vector3Value _groundClickRMB;
        [SerializeField] private Transform _groundTransform;

        private Plane _groundPlane;

        private void Start()
        {
            _groundPlane = new Plane(_groundTransform.up, 0);
        }

        private void Update()
        {
            if (!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(1))
                return;

            if (_eventSystem.IsPointerOverGameObject())
                return;

            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Input.GetMouseButtonUp(0))
            {
                var hits = Physics.RaycastAll(ray);
                if (hits.Length == 0)
                    return;    
                
                foreach (var selectable in hits)
                {
                    if (!selectable.collider.TryGetComponent(out ISelectable component))
                    {
                        _selectedObj.SetValue(null);
                        return;
                    }

                    _selectedObj.SetValue(component);
                    return;
                }
            }
            else if (Input.GetMouseButton(1))
            {
                if (_groundPlane.Raycast(ray, out var enter))
                    _groundClickRMB.SetValue(ray.origin + ray.direction * enter);
                
                var isAttackHit = Physics.RaycastAll(ray);
                if (isAttackHit.Length == 0)
                    return;

                foreach (var attackable in isAttackHit)
                {
                    if (!attackable.collider.TryGetComponent(out IAttackable component))
                        return;
                    _attackRMB.SetValue(component);
                }
            }
            
            
        }
    }

}
