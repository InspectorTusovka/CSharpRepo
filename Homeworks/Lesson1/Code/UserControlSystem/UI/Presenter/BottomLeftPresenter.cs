using Code.Abstraction;
using Code.UserControlSystem.UI.Model;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UserControlSystem.UI.Presenter
{
    public class BottomLeftPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectedValue;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;
        private void Start()
        {
            _selectedValue.OnSelected += onSelected;
            onSelected(_selectedValue.CurrentValue);
        }
        public void onSelected(ISelectable selected)
        {
            _image.enabled = selected != null;
            _healthSlider.gameObject.SetActive(selected != null);
            _text.enabled = selected != null;

            if (selected != null)
            {
                _image.sprite = selected.Icon;
                _text.text = $"{selected.health}/{selected.maxHealth}";
                _healthSlider.minValue = 0;
                _healthSlider.maxValue = selected.maxHealth;
                _healthSlider.value = selected.health;
            }
        }
    }

}
