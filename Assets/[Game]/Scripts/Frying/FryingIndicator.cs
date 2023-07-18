using Game.Props;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime
{
    public class FryingIndicator : MonoBehaviour
    {
        [Header("References")]
        [SerializeField]
        Image indicatorImage;

        private float _startHeight;
        private Transform _myTransform;

        private void Awake()
        {
            _myTransform = transform;
            _startHeight = _myTransform.position.y;
        }

        private void OnEnable()
        {
            FryingOil.OnFry += Increase;
        }

        private void OnDisable()
        {
            FryingOil.OnFry -= Increase;
        }

        private void Increase()
        {
            
        }
    }
}

