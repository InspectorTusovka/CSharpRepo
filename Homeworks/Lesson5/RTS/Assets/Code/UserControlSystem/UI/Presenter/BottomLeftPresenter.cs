using System;
using Code.Abstraction;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UserControlSystem.UI.Presenter
{
    public class BottomLeftPresenter : MonoBehaviour
    {
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _text;

        [Inject] private IObservable<ISelectable> _selectableValue;

        private void Start()
            => _selectableValue.Subscribe(onSelected);
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
