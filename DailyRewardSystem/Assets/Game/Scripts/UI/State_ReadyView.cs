// ----- C#
using InGame.DailySystem.ForManage;
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace InGame.ForUI
{
    public class State_ReadyView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Daily System")]
        [SerializeField] Button _BTN_dailyPopUp = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        private void Start()
        {
            OnInitToDailyRewardView(null);
        }

        public void OnInitToDailyRewardView(Action dailyPopUpOnClick)
        {
            if (_BTN_dailyPopUp.onClick.GetPersistentEventCount() > 1)
                return;

        }
    }
}