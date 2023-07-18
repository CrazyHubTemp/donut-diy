using DG.Tweening;
using Game.Interfaces;
using Game.Runtime;
using UnityEngine;

namespace Game.Props
{
    public class FryingOil : MonoBehaviour
    {
        private IFryable _curFryable;
        private bool _isInteracted = false;
        private Vector3 interactedPoint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IFryable>(out _curFryable))
                _isInteracted = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (!_isInteracted) return;
            _curFryable.Fry();          
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent<IFryable>(out _curFryable))
            {
                _isInteracted = false;
                _curFryable.StopFrying();
                _curFryable = null;
            }
        }
    }
}

