using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime 
{
    public class DragMovementAlong : LeanDragTranslateAlong
    {
        [Header("Drag Movement Along")]
        [SerializeField] private float heightOffset;
        [SerializeField] private LayerMask ignoreLayer;

        private const float RAYCAST_ORIGIN_OFFSET = 3f;
        private const float RAYCAST_DISTANCE = 250f;

        private RaycastHit? _lastRaycastHit = null;

        private void FixedUpdate()
        {
            SetHitPoint();
        }

        protected override void SetTargetPosition(Transform target, Vector3 oldPosition, Vector3 remainingDelta, Vector3 newDelta)
        {
            Vector3 targetPosition = oldPosition + remainingDelta - newDelta;
            targetPosition.y = _lastRaycastHit != null ? GetHeight() : targetPosition.y;
            target.position = targetPosition;
        }

        private void SetHitPoint() 
        {
            Vector3 origin = transform.position + RAYCAST_ORIGIN_OFFSET * Vector3.up;
            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, RAYCAST_DISTANCE, ~ignoreLayer))
            {
                _lastRaycastHit = hit;
            }
        }

        private float GetHeight() 
        {
            return _lastRaycastHit.Value.point.y + heightOffset;
        }
    }
}

