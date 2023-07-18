using DG.Tweening;
using Game.Interfaces;
using Game.Models;
using UnityEngine;

namespace Game.Runtime
{
    public class Fryable : MonoBehaviour, IFryable
    {
        [field: SerializeField] public FryingData FryingData { get; private set; } = new();

        [SerializeField]
        private MeshRenderer mesh;

        private Tween _fryingTween;

        [Sirenix.OdinInspector.Button]
        public void Fry()
        {
            if (_fryingTween != null)
            {
                _fryingTween.Play();
                return;
            }

            _fryingTween = mesh.material.DOGradientColor(FryingData.FryingGradient, FryingData.BurnedTime);
        }

        public void StopFrying()
        {
            _fryingTween.Pause();
        }
    }
}
