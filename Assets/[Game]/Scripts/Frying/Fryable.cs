using DG.Tweening;
using Game.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime
{
    public class Fryable : MonoBehaviour, IFryable
    {
        [SerializeField]
        private MeshRenderer mesh; 
        private Sequence _fryingSeq;

        [Sirenix.OdinInspector.Button]

        public void Fry()
        {
        }
        public void StopFrying()
        {
        }
    }
}
