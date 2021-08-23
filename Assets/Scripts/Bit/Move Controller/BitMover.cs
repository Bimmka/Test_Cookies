using UnityEngine;

namespace Bit
{
    [RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(BitReflectionCreator))]
    public class BitMover : MonoBehaviour
    {
        private Rigidbody bitRigidbody;

        private void Awake()
        {
            bitRigidbody = GetComponent<Rigidbody>();
            BitMoveDirectionCreator.OnClampedMousePositionCreated += Move;
        }

        private void OnDestroy()
        {
            BitMoveDirectionCreator.OnClampedMousePositionCreated -= Move;
        }

        private void Move(float clampedMousePosition)
        {
            bitRigidbody.MovePosition(new Vector3(clampedMousePosition, bitRigidbody.position.y, bitRigidbody.position.z));
        }
    }
}

