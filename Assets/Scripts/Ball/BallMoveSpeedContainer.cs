using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bit;
using Level;

namespace Ball
{
    public class BallMoveSpeedContainer : MonoBehaviour
    {
        [SerializeField] private float[] speeds;

        private int currentSpeedIndex = 0;

        public float CurrentSpeed => speeds[currentSpeedIndex];

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.GetComponent<BitReflectionCreator>() != null)
                IncSpeed();
            else if (other.collider.GetComponent<Side>() != null)
                CutInHalfSpeed();
        }

        private void IncSpeed()
        {
            currentSpeedIndex++;
            currentSpeedIndex = Mathf.Clamp(currentSpeedIndex,0,speeds.Length-1);
        }

        private void CutInHalfSpeed()
        {
            currentSpeedIndex /= 2;
        }
    }
}

