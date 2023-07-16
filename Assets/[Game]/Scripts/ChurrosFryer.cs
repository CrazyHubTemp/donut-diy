using UnityEngine;

namespace Game.Runtime
{
    public class ChurrosFryer : MonoBehaviour
    {
        private void OnEnable()
        {
            InputManager.Instance.OnTouch.AddListener(FryChurro);
        }

        private void OnDisable()
        {
            InputManager.Instance.OnTouch.RemoveListener(FryChurro);
        }

        private void FryChurro(TouchData data)
        {
            if (data.IsTouched)
                StartFrying();
            else
                StopFrying();
        }

        private void StartFrying()
        {
            Debug.Log("Fry");
        }

        private void StopFrying()
        {
            Debug.Log("Stop Fry");
        }
    }
}
