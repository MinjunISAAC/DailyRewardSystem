// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForData.User;
using InGame.UI;

namespace Main
{
    public class Main : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private MainUI _mainUI = null;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private IEnumerator Start()
        {
            // User Save Data Load
            UserSaveDataManager.CreateToUserSaveData();
            UserSaveDataManager.Load();

            var userData = UserSaveDataManager.UserSaveData;

            // Static Manage Init
            var assetHubView = _mainUI.AssetHubView;

            // UI Init
            assetHubView.OnInit(userData.UserCoin, userData.UserGem);

            yield return null;
        }
    }
}