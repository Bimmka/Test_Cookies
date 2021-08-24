using UnityEngine;

public class BitReflectionCreator : MonoBehaviour
{
    [SerializeField] private float maxReflectionXDirection;
    
    float maxDeltaXPosition;

#if UNITY_EDITOR
    private void OnValidate()
    {
        maxReflectionXDirection = Mathf.Clamp01(maxReflectionXDirection);
    }
    #endif

    private void Awake()
    {
        maxDeltaXPosition = (transform.lossyScale/2).x;
    }

    public Vector3 GetReflectionDirection(ContactPoint contactPoint)
    {
        float deltaPosition = (contactPoint.point - transform.position).x;
       
        return new Vector3((deltaPosition / maxDeltaXPosition) * maxReflectionXDirection, 0, transform.forward.z).normalized;
    }
}
