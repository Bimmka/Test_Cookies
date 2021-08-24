using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UITouchCountDisplayer : MonoBehaviour
    {
        [SerializeField] private Text bitTouchCountText;
        [SerializeField] private Text sideTouchCountText;

        private void Awake()
        {
            TouchCalculator.OnTouchCountUpdated += UpdateTouchCountText;
        }

        private void OnDestroy()
        {
            TouchCalculator.OnTouchCountUpdated -= UpdateTouchCountText;
        }

        private void UpdateTouchCountText(TouchedElementType type, int touchCount)
        {
            if (type == TouchedElementType.Bit)
                UpdateBitTouchCount(touchCount);
            else
                UpdateSideTouchCountText(touchCount);
        }

        private void UpdateBitTouchCount(int touchCount)
        {
            bitTouchCountText.text = touchCount.ToString();
        }

        private void UpdateSideTouchCountText(int touchCount)
        {
            sideTouchCountText.text = touchCount.ToString();
        }

    }
}

