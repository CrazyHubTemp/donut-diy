using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Enums;

namespace Game.Runtime
{   
    public class ToppingState : GameStateBase
    {
        public ToppingState(GameStateMachine stateMachine) : base(stateMachine) { }       

        public override IEnumerator EnterState()
        {
            UIManager.Instance.ShowPanel(PanelID.ToppingSelectionPanel);
            GameStateManager.Instance.OnEnterToppingState.Invoke();
            yield break;
        }

        public override IEnumerator ExitState()
        {
            UIManager.Instance.HidePanel(PanelID.ToppingSelectionPanel);
            GameStateManager.Instance.OnExitToppingState.Invoke();
            yield break;
        }
    }
}

