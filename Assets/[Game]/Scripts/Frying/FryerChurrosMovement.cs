using DG.Tweening;
using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime 
{
    public class FryerChurrosMovement : MonoBehaviour
    {
        private Churros CurrentChurros => ChurrosManager.Instance.CurrentChurros;

        [SerializeField] private Transform churrosParent;

        private const float MOVEMENT_OFFSET = 2f;
        private const float MOVEMENT_DURATION = 1f;
        private const Ease MOVEMENT_EASE = Ease.Linear;

        private Tween _movementTween;

        private void OnEnable()
        {
            GameStateManager.Instance.OnEnterChurrosFryingState.AddListener(MoveTowardsFryer);
        }

        private void OnDisable()
        {
            GameStateManager.Instance.OnEnterChurrosFryingState.RemoveListener(MoveTowardsFryer);
        }

        private void MoveTowardsFryer() 
        {
            Vector3 startPosition = churrosParent.position + MOVEMENT_OFFSET * Vector3.up;
            CurrentChurros.transform.position = startPosition;
            CurrentChurros.transform.SetParent(churrosParent);
            MovementTween(CurrentChurros.transform);
        }

        private void MovementTween(Transform target) 
        {
            _movementTween?.Kill();
            _movementTween = target.DOLocalMove(Vector3.zero, MOVEMENT_DURATION).SetEase(MOVEMENT_EASE);
        }
    }
}

