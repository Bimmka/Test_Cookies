using System;
using System.Collections;
using System.Collections.Generic;
using Ball;
using UnityEngine;


public class TouchCalculator : MonoBehaviour
{
    [SerializeField] private TouchedElementType type;
    
    private int currentTouchCount;
    
    public static event Action<TouchedElementType,int> OnTouchCountUpdated;

    private void Start()
    {
        NotifyAboutTouchCountUpdate();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.GetComponent<BallMover>())
            IncTouchCount();
    }

    private void IncTouchCount()
    {
        currentTouchCount++;
        NotifyAboutTouchCountUpdate();
    }

    private void NotifyAboutTouchCountUpdate()
    {
        OnTouchCountUpdated?.Invoke(type, currentTouchCount);
    }
}

public enum TouchedElementType
{
    Bit, 
    Side
}

