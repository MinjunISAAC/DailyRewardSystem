// ----- C#
using System;
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForAsset;
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
        [SerializeField] private State_ReadyView _readyView       = null;

        [Space(1.5f)] [Header("Asset UI Group")]
        [SerializeField] private AssetHubSystem    _assetHubView    = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public AssetHubSystem   AssetHubView   => _assetHubView;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
    }
}