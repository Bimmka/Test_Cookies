using System;
using System.Collections;
using GameControlls;
using UnityEngine;

namespace Ball
{
    public class BallFVXRotator : MonoBehaviour
    {
        [SerializeField] private Transform ballViewTransform;
        [SerializeField] private float baseRotateSpeed = 100;
        [SerializeField] private float rotateCoeffBySpeed = 1.5f;

        private BallMoveSpeedContainer speedsContainer;

        private void Awake()
        {
            speedsContainer = GetComponent<BallMoveSpeedContainer>();
            GameStarter.OnGameStarted += StartRotate;
        }

        private void OnDestroy()
        {
            GameStarter.OnGameStarted -= StartRotate;
        }

        private void StartRotate()
        {
            StartCoroutine(Rotate());
        }

        private IEnumerator Rotate()
        {
            while (gameObject.activeSelf)
            {
                RotateView();
                yield return null;
            }
        
        }

        private void RotateView()
        {
            ballViewTransform.rotation = Quaternion.Euler(0,ballViewTransform.eulerAngles.y + GetCurrentRotateSpeed(),0);
        }

        private float GetCurrentRotateSpeed()
        {
            return (baseRotateSpeed + speedsContainer.CurrentSpeed * rotateCoeffBySpeed) * Time.deltaTime;
        }
    }
}

