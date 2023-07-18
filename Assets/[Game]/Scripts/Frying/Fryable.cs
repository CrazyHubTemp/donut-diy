using DG.Tweening;
using Game.Interfaces;
using Game.Models;
using Game.Props;
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
            if (FryingData.IsFryingStarted)
            {
                _fryingTween.Play();
                return;
            }

            FryingData.IsFryingStarted = true;
            _fryingTween = mesh.material.DOGradientColor(FryingData.FryingGradient, FryingData.BurnedTime)
                .OnUpdate(()=> {
                    FryingData.FryingDuration += Time.deltaTime;
                    FryingOil.OnFry?.Invoke(FryingData);
                });
        }

        public void StopFrying()
        {
            _fryingTween.Pause();
        }
    }
}
