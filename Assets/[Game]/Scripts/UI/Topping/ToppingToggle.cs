using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Models;
using Game.Managers;

namespace Game.UI 
{
    public class ToppingToggle : MonoBehaviour
    {
        private Toggle _toggle;
        public Toggle Toggle => _toggle == null ? _toggle = GetComponent<Toggle>() : _toggle;
        public ToppingData ToppingData { get; private set; }
        public ToggleGroup ToggleGroup { get; private set; }

        [SerializeField] private Image iconImage;
        [SerializeField] private GameObject selectedHighlight;

        private void OnEnable()
        {
            Toggle.onValueChanged.AddListener(ToggleItem);
        }

        private void OnDisable()
        {
            Toggle.onValueChanged.RemoveListener(ToggleItem);
        }

        public void Initialize(ToppingData toppingData, ToggleGroup toggleGroup, bool isDefault = false) 
        {
            ToppingData = toppingData;
            ToggleGroup = toggleGroup;
            Toggle.group = ToggleGroup;        
            SetIcon();
            ToggleItem(isDefault);
        }

        public void ToggleItem(bool isSelected)
        {
            selectedHighlight.SetActive(isSelected);
            if (isSelected)
            {
                ToppingManager.Instance.SetCurrentToppingData(ToppingData);
                ToppingManager.Instance.OnToppingChanged.Invoke(ToppingData);
                if (LevelManager.Instance.IsLevelStarted)
                    SoundManager.Instance.PlaySound(AudioID.ToppingSelection);
            }
        }   
        
        public void SetDefault() 
        {
            Toggle.isOn = true;
            ToggleItem(true);
        }

        private void SetIcon() 
        {
            iconImage.sprite = ToppingData.Icon;
        }        
    }
}

