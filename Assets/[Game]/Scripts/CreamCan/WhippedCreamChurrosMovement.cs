using DG.Tweening;
using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime 
{
    public class WhippedCreamChurrosMovement : MonoBehaviour
    {
        private Churros CurrentChurros => ChurrosManager.Instance.CurrentChurros;

        [SerializeField] private Transform churrosParent;

        private const float MOVEMENT_OFFSET = 0.5f;
        private const float MOVEMENT_DURATION = 0.5f;
        private const Ease MOVEMENT_EASE = Ease.Linear;

        private Tween _movementTween;

        private void OnEnable()
        {
            GameStateManager.Instance.OnEnterWhippedCreamState.AddListener(MoveTowardsPlate);
        }

        private void OnDisable()
        {
            GameStateManager.Instance.OnEnterWhippedCreamState.RemoveListener(MoveTowardsPlate);
        }

        private void MoveTowardsPlate()
        {           
            CurrentChurros.transform.position += MOVEMENT_OFFSET * Vector3.up;
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
