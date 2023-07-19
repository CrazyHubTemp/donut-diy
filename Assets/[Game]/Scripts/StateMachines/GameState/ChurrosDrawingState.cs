using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enums;
using DG.Tweening;

namespace Game.Runtime 
{   
    public class ChurrosDrawingState : GameStateBase
    {
        public ChurrosDrawingState(GameStateMachine stateMachine) : base(stateMachine) { }

        private const float CAMERA_BLEND_DURATION = 1f;
        private const float EVENT_DELAY = 0.25f;

        public override IEnumerator EnterState()
        {            
            CameraManager.Instance.ActivateCamera(CameraID.DrawingCamera, CAMERA_BLEND_DURATION);
            yield return new WaitForSeconds(EVENT_DELAY);
            GameStateManager.Instance.OnEnterChurrosDrawingState.Invoke();
        }

        public override IEnumerator ExitState()
        {
            GameStateManager.Instance.OnExitChurrosDrawingState.Invoke();
            yield break;
        }
    }
}

