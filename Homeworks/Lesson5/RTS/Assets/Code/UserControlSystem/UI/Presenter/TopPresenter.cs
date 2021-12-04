using System;
using Code.Abstraction;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UserControlSystem.UI.Presenter
{
    public sealed class TopPresenter : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _menuButton;
        [SerializeField] private GameObject _menuGo;

        [Inject]
        private void Init(ITimeModel timeModel)
        {
            timeModel.GameTime.Subscribe(seconds =>
            {
                var t = TimeSpan.FromSeconds(seconds);
                _inputField.text = $"{t.Minutes:D2}:{t.Seconds:D2}";
            });
            _inputField.interactable = false;
            _menuButton.OnClickAsObservable().Subscribe(_ => Pause());
        }

        private void Pause()
        {
            _menuGo.SetActive(true);
            Time.timeScale = 0;
        }
    }
}