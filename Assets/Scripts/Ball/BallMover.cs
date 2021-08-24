using System;
using System.Collections;
using GameControlls;
using Level;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Ball
{
    [RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(BallMoveSpeedContainer)), RequireComponent(typeof(BallFVXRotator))]
    public class BallMover : MonoBehaviour
    {
        [SerializeField] private Vector3 startedMoveVector;
        
        private Rigidbody ballRigidbody;
        private BallMoveSpeedContainer speedsContainer;

        private Vector3 moveDirection;

        private void Awake()
        {
            ballRigidbody = GetComponent<Rigidbody>();
            speedsContainer = GetComponent<BallMoveSpeedContainer>();
            GameStarter.OnGameStarted += StartMove;
        }

        private void OnDestroy()
        {
            GameStarter.OnGameStarted -= StartMove;
        }

        private void StartMove()
        {
            SetRandomStartedMoveDirection();
            StartCoroutine(FixedMove());
        }

        private void SetRandomStartedMoveDirection()
        {
            Vector3 randomDirection = new Vector3(
                Random.Range(-startedMoveVector.x, startedMoveVector.x),
                0,
                Random.Range(-startedMoveVector.z, startedMoveVector.z))
                .normalized;
            
            if (randomDirection == Vector3.zero)
                randomDirection+=Vector3.forward;
            
            UpdateMoveDirection(randomDirection);
        }

        private IEnumerator FixedMove()
        {
            while (gameObject.activeSelf)
            {
                ballRigidbody.MovePosition(ballRigidbody.position + moveDirection * (speedsContainer.CurrentSpeed * Time.fixedDeltaTime));
                yield return new WaitForFixedUpdate();
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.GetComponent<LevelElement>() != null)
                UpdateMoveDirection(Vector3.Reflect(moveDirection, other.contacts[0].normal));
            else
                if (other.collider.TryGetComponent(out BitReflectionCreator reflectionCreator))
                    UpdateMoveDirection(reflectionCreator.GetReflectionDirection(other.contacts[0]));
        }

        private void UpdateMoveDirection(Vector3 direction)
        {
            moveDirection = direction;
        }
    }
}
