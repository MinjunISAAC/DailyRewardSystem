// ----- C#
using InGame.DailySystem.ForData;
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

// ----- User Defined
using Utility.ForAsset;

namespace InGame.DailySystem.ForUI
{
    public class DailyPopUpView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("UI Components")]
        [SerializeField] private Button                _BTN_Close  = null;
         
        [Space(1.5f)] [Header("Item Prefab")]
        [SerializeField] private List<DailyRewardItem> _dailyItems = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit()
        {
            if (_BTN_Close.onClick.GetPersistentEventCount() > 1)
                return;

            _BTN_Close.onClick.AddListener(() => gameObject.SetActive(false));
        }

        public void SetToRewardItems(DailyRewardData datas, Action<EAssetType, int> onClick)
        {
            for (int i = 0; i < _dailyItems.Count; i++)
            {
                var item  = _dailyItems[i];
                var type  = int.Parse(datas.dataSet[i].type);
                var value = datas.dataSet[i].values[type];

                item.OnInIt(i, type, value, onClick);
            }
        }
    }
}