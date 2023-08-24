// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForAsset.ForUI;

namespace InGame.UI
{
    public class MainUI : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("UI Group")]
        [SerializeField] private AssetHubView _assetHubView = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public AssetHubView AssetHubView => _assetHubView;
    }
}