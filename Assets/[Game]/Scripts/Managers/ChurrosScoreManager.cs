using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Interfaces;

namespace Game.Managers 
{
    public class ChurrosScoreManager : Singleton<ChurrosScoreManager>
    {
        public float ChurrosHeatProgress { get; private set; }
        public bool HasBadIngredient { get; private set; }

        private const float MIN_HEAT = 0.25f;
        private const float MAX_HEAT = 0.75f;

        private void OnEnable()
        {
            LevelManager.Instance.OnLevelFinished.AddListener(ResetValues);
        }

        private void OnDisable()
        {
            LevelManager.Instance.OnLevelFinished.RemoveListener(ResetValues);
        }

        public void SetIngredient(IIngredientData ingredientData) 
        {
            if (!ingredientData.IsBad)
                return;

            HasBadIngredient = true;
        }

        public void SetChurrosHeatProgress(float progress) 
        {
            ChurrosHeatProgress = progress;
        }

        public bool IsChurrosGood() 
        {            
            return !HasBadIngredient && (ChurrosHeatProgress >= MIN_HEAT && ChurrosHeatProgress <= MAX_HEAT);
        }

        private void ResetValues() 
        {
            HasBadIngredient = false;
        }
    }
}
