using DG.Tweening;
using Lean.Touch;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime
{
    public class CreamCan : MonoBehaviour
    {
        private LeanSelectableByFinger _leanSelectable;
        private LeanSelectableByFinger LeanSelectable => _leanSelectable == null ? _leanSelectable = GetComponent<LeanSelectableByFinger>() : _leanSelectable;

        [SerializeField] private Transform graphics;
        [SerializeField] private LayerMask ignoreLayer;

        private Vector3 _initialRotation;
        private float _initialY;
        private Tween _rotationTween;

        private const float TARGET_ROTATION_Z = 140f;
        private const float OFFSET_Y = 0.02f;

        private void Awake()
        {
            _initialRotation = graphics.localEulerAngles;
            _initialY = graphics.position.y;
        }

        private void OnEnable()
        {
            LeanSelectable.OnSelectedFinger.AddListener(SelectTween);
            LeanSelectable.OnSelectedFingerUp.AddListener(DeselectTween);
        }

        private void OnDisable()
        {
            LeanSelectable.OnSelectedFinger.RemoveListener(SelectTween);
            LeanSelectable.OnSelectedFingerUp.RemoveListener(DeselectTween);
        }

        private void Update()
        {
            UpdateHeight();
        }

        private void UpdateHeight()
        {
            if (!LeanSelectable.IsSelected)
                return;

            graphics.position = Vector3.Lerp(graphics.position, GetHeight(), 5 * Time.deltaTime);
        }

        private Vector3 GetHeight()
        {
            if (Physics.Raycast(graphics.position + (Vector3.up * 0.1f), Vector3.down, out RaycastHit hit, 1000, ~ignoreLayer))
                return new(graphics.position.x, hit.point.y + OFFSET_Y, graphics.position.z);

            return Vector3.zero;
        }

        private void SelectTween(LeanFinger arg0)
        {
            Vector3 targetRotation = new(_initialRotation.x, _initialRotation.y, TARGET_ROTATION_Z);
            _rotationTween?.Kill();
            _rotationTween = graphics.DOLocalRotate(targetRotation, 0.6f);
        }

        private void DeselectTween(LeanFinger arg0)
        {
            _rotationTween?.Kill();
            _rotationTween = graphics.DOLocalRotate(_initialRotation, 0.25f);
            graphics.DOMoveY(_initialY, 0.25f);
        }
    }
}