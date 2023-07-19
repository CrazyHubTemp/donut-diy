using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Runtime 
{   
    public class WhippedCreamState : GameStateBase
    {
        public WhippedCreamState(GameStateMachine stateMachine) : base(stateMachine) { }        

        public override IEnumerator EnterState()
        {
            GameStateManager.Instance.OnEnterWhippedCreamState.Invoke();
            yield break;
        }

        public override IEnumerator ExitState()
        {
            GameStateManager.Instance.OnExitWhippedCreamState.Invoke();
            yield break;
        }
    }
}
