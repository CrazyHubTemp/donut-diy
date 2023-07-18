using Game.Interfaces;
using Game.Models;
using System;
using UnityEngine;

namespace Game.Props
{
    public class FryingOil : MonoBehaviour
    {
        public static Action<FryingData> OnFry;

        private IFryable _curFryable;
        private bool _isInteracted = false;
        private Vector3 interactedPoint;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<IFryable>(out _curFryable))
            {
                _isInteracted = true;

                _curFryable.Fry();

            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (!_isInteracted) return;
            OnFry?.Invoke(_curFryable.FryingData);
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

