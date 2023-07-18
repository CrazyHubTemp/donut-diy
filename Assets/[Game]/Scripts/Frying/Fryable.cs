using DG.Tweening;
using Game.Interfaces;
using UnityEngine;

namespace Game.Runtime
{
    public class Fryable : MonoBehaviour, IFryable
    {
        [SerializeField]
        private MeshRenderer mesh;

        private Tween _colorTween;

        [Sirenix.OdinInspector.Button]

        public void Fry()
        {
        }
        public void StopFrying()
        {
        }
    }
}
