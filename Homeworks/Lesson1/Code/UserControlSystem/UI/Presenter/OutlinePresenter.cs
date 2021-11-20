using Code.Abstraction;
using Code.UserControlSystem.UI.Model;
using System;
using UnityEngine;

namespace Code.UserControlSystem.UI.Presenter
{
    public sealed class OutlinePresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedValue;
        private Outline isSelected;
        private ISelectable _currentSelected;

        private void Start()
        {
            _selectedValue.OnSelected += onSelected;
            onSelected(_selectedValue.CurrentValue);
        }

        public void onSelected(ISelectable value)
        {
            if (_currentSelected == value)
                return;

            _currentSelected = value;

            SetOutline(isSelected, false);
            isSelected = null;

            if (value != null)
            {
                isSelected = (value as Component).GetComponent<Outline>();
                SetOutline(isSelected, true);
            }

        }

        static private void SetOutline(Outline isSelected, bool flag)
        {
            if (isSelected != null)
                isSelected.enabled = flag;
        }
    }

}
