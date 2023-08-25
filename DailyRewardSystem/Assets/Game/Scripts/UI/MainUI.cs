// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForAsset.ForUI;
using InGame.DailySystem.ForUI;

namespace InGame.ForUI
{
    public class MainUI : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("State UI Group")]
        [SerializeField] private State_ReadyView _readyView    = null;

        [Header("UI Group")]
        [SerializeField] private DailyPopUpView _dailyPopUpView = null;

        [Space(1.5f)] [Header("Asset UI Group")]
        [SerializeField] private AssetHubView    _assetHubView = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public AssetHubView   AssetHubView   => _assetHubView;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInitToStateUI(Action onClick)
        {
            _readyView.OnInit(onClick);
        }

        public void OnInitToDailyPopUp() => _dailyPopUpView.OnInit(() => VisiableDailyPopUp(false));

        public void VisiableDailyPopUp(bool visiable) => _dailyPopUpView.gameObject.SetActive(visiable);
    }
}