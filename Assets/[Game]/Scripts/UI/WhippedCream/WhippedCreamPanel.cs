using Game.Models;
using Game.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Runtime
{
    public class WhippedCreamPanel : EasyPanel
    {
        private ToggleGroup _toggleGroup;
        private ToggleGroup ToggleGroup => _toggleGroup == null ? _toggleGroup = GetComponentInChildren<ToggleGroup>() : _toggleGroup;

        [SerializeField] private CreamDataHolder creamDatabase;
        [SerializeField] private Transform content;
        [SerializeField] private CreamItemUI creamItemPrefab;

        private List<CreamItemUI> _creamItems = new();
        private CreamItemUI _defaultCreamItem;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            CreateCreamItems();
        }

        public override void ShowPanel()
        {
            SelectDefaultItem();
            base.ShowPanel();
        }

        private void SelectDefaultItem()
        {
            _defaultCreamItem.ToggleItem(true);
        }

        private void CreateCreamItems()
        {
            List<CreamData> creams = new(creamDatabase.Creams);
            creams.Remove(creamDatabase.DefaultCreamData);

            //Instantiate the default as first
            CreamItemUI item = Instantiate(creamItemPrefab, content);
            _creamItems.Add(item);
            _defaultCreamItem = item;
            item.Initialize(creamDatabase.DefaultCreamData, ToggleGroup);

            //Instantiate the rest
            foreach (CreamData creamData in creams)
            {
                item = Instantiate(creamItemPrefab, content);
                _creamItems.Add(item);
                item.Initialize(creamData, ToggleGroup);
            }
        }
    }
}