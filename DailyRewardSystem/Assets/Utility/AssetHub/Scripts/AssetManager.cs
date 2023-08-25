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
        private static AssetHubView _assetHubView = null;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        public static AssetHubView AssetHubView => _assetHubView;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public static void SetAssetHubView(AssetHubView assetHubView)
        {
            if (_assetHubView != null)
                return;

            _assetHubView = assetHubView;
        }
    }
}