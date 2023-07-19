using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enums;

namespace Game.Runtime 
{
    public class ChurrosFryingState : GameStateBase
    {
        public ChurrosFryingState(GameStateMachine stateMachine) : base(stateMachine) { }

        private const float CAMERA_BLEND_DURATION = 1f;
        private const float STATE_DELAY = 1f;
        private const float EVENT_DELAY = 0.25f;

        public override IEnumerator EnterState()
        {     
            yield return new WaitForSeconds(STATE_DELAY);
            CameraManager.Instance.ActivateCamera(CameraID.FryingCamera, CAMERA_BLEND_DURATION);
            yield return new WaitForSeconds(EVENT_DELAY);
            GameStateManager.Instance.OnEnterChurrosFryingState.Invoke();
        }
    }
}

