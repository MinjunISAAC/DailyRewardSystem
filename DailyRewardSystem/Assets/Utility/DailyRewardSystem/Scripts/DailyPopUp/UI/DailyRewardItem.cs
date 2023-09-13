// ----- C#
using System;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Utility.ForAsset;
using Utility.ForData.User;

namespace InGame.DailySystem.ForUI
{
    public class DailyRewardItem : MonoBehaviour
    {
        // --------------------------------------------------
        // Enum
        // --------------------------------------------------

        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Button")]
        [SerializeField] private Button          _BTN_Click         = null;
        [SerializeField] private Animation       _ANIM_Purchase     = null;

        [Space(1.5f)] [Header("Texts")]
        [SerializeField] private TextMeshProUGUI _TMP_dayText       = null;
        [SerializeField] private TextMeshProUGUI _TMP_cost          = null;

        [Space(1.5f)] [Header("Images")]
        [SerializeField] private Image           _IMG_Frame         = null;
        [SerializeField] private Image           _IMG_Hide          = null;
        [SerializeField] private Image           _IMG_Icon          = null;
        
        [Space(1f)]
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

            // Button ���� 
            if (_BTN_Click.onClick.GetPersistentEventCount() > 1)
                return;

            _BTN_Click.onClick.AddListener
            (
                () => 
                { 
                    onClick((EAssetType)(type + 1), value);

                    _IMG_Frame.sprite  = _SPRITE_UnPurchase;
                    _BTN_Click.enabled = false;
                    
                    _IMG_Hide.gameObject.SetActive(true);
                    _ANIM_Purchase.Play();

                    //Debug.Log($"Asset {index} {type} {value}");
                }
            );

            // Hide Image ����
            _RefreshUI(index);
        }

        private void _RefreshUI(int index)
        {
            if (index == UserSaveDataManager.GetAcquiredItemIndex())     // �Դ� �� �ΰ��
            {
                _IMG_Frame.sprite       = _SPRITE_Purchase;
                _BTN_Click.enabled      = true;
                
                _IMG_Hide.gameObject.SetActive(false);
            }
            else if (index < UserSaveDataManager.GetAcquiredItemIndex()) // ���� ������ ���
            {
                _IMG_Frame.sprite  = _SPRITE_UnPurchase;
                _BTN_Click.enabled = false;
                
                _IMG_Hide.gameObject.SetActive(true);
            }
            else if (index > UserSaveDataManager.GetAcquiredItemIndex()) // ���� ���ϴ� ���
            {
                _IMG_Frame.sprite  = _SPRITE_UnPurchase;
                _BTN_Click.enabled = false;
            }
        }
    }
}