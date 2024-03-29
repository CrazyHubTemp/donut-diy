using Game.Helpers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Game.UI;

namespace Game.Managers 
{
    public class CurrencyManager : Singleton<CurrencyManager>
    {
        public static int CurrenyAmount
        {
            get
            {
                return PlayerPrefs.GetInt(PlayerPrefsKeys.CurrencyAmount, 0);
            }
            private set
            {
                PlayerPrefs.SetInt(PlayerPrefsKeys.CurrencyAmount, value);
            }
        }

        public CurrencyPanel CurrencyPanel { get; private set; }
        public UnityEvent OnCurrencyAmountChanged { get; } = new UnityEvent();
        public UnityEvent OnSuccessRewardClaimed { get; } = new UnityEvent();

        public void AddCurrency(int amount)
        {
            CurrenyAmount += amount;
            OnCurrencyAmountChanged.Invoke();
        }

        public void SetCurrencyPanel(CurrencyPanel currencyPanel)
        {
            CurrencyPanel = currencyPanel;
        }
    }
}

