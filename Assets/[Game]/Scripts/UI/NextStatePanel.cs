using Game.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI 
{
    public class NextStatePanel : EasyPanel
    {
        public bool IsActive { get; private set; }

        public override void ShowPanel()
        {
            base.ShowPanel();
            IsActive = true;
        }

        public void NextStateButton() 
        {
            if (!IsActive)
                return;

            IsActive = false;
            GameStateManager.Instance.CurrentStateMachine.EnterNextState();
        }
    }
}

