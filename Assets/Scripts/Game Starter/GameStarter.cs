using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameControlls
{
    public class GameStarter : MonoBehaviour
    {
        public static event Action OnGameStarted;

        private bool isStarted;

        private void Awake()
        {
            StartCoroutine(WaitToClick());
        }

        private IEnumerator WaitToClick()
        {
            while (!isStarted)
            {
                if (IsClicked())
                    StartGame();
                yield return null;
            }
        }

        private bool IsClicked()
        {
            return Input.GetMouseButtonDown(0);
        }

        private void StartGame()
        {
            NotifyAboutStart();
            SetIsStartedTrue();
        }

        private void NotifyAboutStart()
        {
            OnGameStarted?.Invoke();
        }

        private void SetIsStartedTrue()
        {
            isStarted = true;
        }
    }
}

