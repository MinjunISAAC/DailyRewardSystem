// ----- C#
using System;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Utility.ForAsset;

namespace InGame.DailySystem.ForUI
{
    public class DailyRewardItem : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Button")]
        [SerializeField] private Button          _BTN_Click         = null;
        
        [Space(1.5f)] [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _TMP_dayText       = null;
        [SerializeField] private TextMeshProUGUI _TMP_cost          = null;

        [Space(1.5f)] [Header("Images")]
        [SerializeField] private Image           _IMG_Hide          = null;
        [SerializeField] private Image           _IMG_Icon          = null;
        [Space()]
        [SerializeField] private Sprite          _SPRITE_UnPurchase = null;
        [SerializeField] private Sprite          _SPRITE_Purchase   = null;
        [SerializeField] private Sprite          _SPRITE_coin       = null;
        [SerializeField] private Sprite          _SPRITE_gem        = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInIt(int index, int type, int value, Action<EAssetType, int> onClick)
        {
            switch (type) 
            {
                case 0: _IMG_Icon.sprite = _SPRITE_coin; break;
                case 1: _IMG_Icon.sprite = _SPRITE_gem;  break;
                default: return;
            }

            
            _TMP_dayText.text = $"{index + 1} DAY";
            _TMP_cost.text    = $"{value}";

            // Button 実特 
            if (_BTN_Click.onClick.GetPersistentEventCount() > 1)
                return;

            _BTN_Click.onClick.AddListener(() => { onClick((EAssetType)(type + 1), value);  Debug.Log($"Asset {index} {type} {value}"); });



            // Hide Image 実特

        }
    }
}