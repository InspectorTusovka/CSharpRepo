using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UserControlSystem.UI.Presenter
{
    public class MenuPresenter : MonoBehaviour
    {
        [SerializeField] private Button _backButoon;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            _backButoon.OnClickAsObservable().Subscribe(_ => Resume());
            _exitButton.OnClickAsObservable().Subscribe(_ => Application.Quit());
        }

        private void Resume()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }
}