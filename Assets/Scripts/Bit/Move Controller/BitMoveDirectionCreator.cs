using System;
using Level;
using UnityEngine;

namespace Bit
{
    public class BitMoveDirectionCreator : MonoBehaviour
    {
        [SerializeField] private LevelElement leftStopWall;
        [SerializeField] private LevelElement rightStopWall;
        
        private float lastMouseXPosition;
        private Camera mainCamera;
        private Plane plane;

        public static event Action<float> OnClampedMousePositionCreated; 
        private void Awake()
        {
            mainCamera = Camera.main;
            plane = new Plane(Vector3.up, 0);
        }
        private void Update()
        {
            OnClampedMousePositionCreated?.Invoke(GetClampedMousePosition());
        }

        private float GetClampedMousePosition()
        {
            float distance;
            float mouseXPosition;
            
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            
            if (plane.Raycast(ray, out distance))
            {
                mouseXPosition = ray.GetPoint(distance).x;
                
                mouseXPosition = Mathf.Clamp(
                    mouseXPosition, 
                    leftStopWall.transform.position.x + leftStopWall.transform.lossyScale.x,
                    rightStopWall.transform.position.x - rightStopWall.transform.lossyScale.x);
                return mouseXPosition;
            }
            
            return 0;
        }

    } 
}

