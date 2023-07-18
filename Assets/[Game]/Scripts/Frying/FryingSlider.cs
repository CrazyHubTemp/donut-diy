using Game.Models;
using Game.Props;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime
{
    public class FryingSlider : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        private Slider slider;

        private void OnEnable()
        {
            FryingOil.OnFry += Increase;
        }

        private void OnDisable()
        {
            FryingOil.OnFry -= Increase;
        }

        private void Increase(FryingData fryingData)
        {
            slider.value += .05f;
        }

        private void ResetSlider()
        {

        }
    }
}

