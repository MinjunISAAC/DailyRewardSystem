// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForAsset.ForUI;

namespace Utility.ForAsset.Manage
{
    public static class AssetManager
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private static AssetHubSystem _assetHubView = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public static AssetHubSystem AssetHubView => _assetHubView;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public static void SetAssetHubView(AssetHubSystem assetHubView)
        {
            if (_assetHubView != null)
                return;

            _assetHubView = assetHubView;
        }
    }
}