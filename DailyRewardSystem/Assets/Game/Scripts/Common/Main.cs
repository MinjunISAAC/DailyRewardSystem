// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForData.User;
using Utility.ForAsset.Manage;
using InGame.ForUI;
using System;
using Utility.ForData.ForJson;
using InGame.DailySystem.ForManage;

namespace Main
{
    public class Main : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private MainUI         _mainUI         = null;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private IEnumerator Start()
        {
            // Json Data Load
            JsonParser.LoadJson();

            // User Save Data Load
            UserSaveDataManager.Load();
            var userData = UserSaveDataManager.UserSaveData;

            // Static Manage Init
            var assetHubView = _mainUI.AssetHubView;
            AssetManager.SetAssetHubView(assetHubView);

            // UI Init
            assetHubView.OnInit(userData.UserCoin, userData.UserGem);
















            /*
            _mainUI.OnInitToStateUI(() => _mainUI.VisiableDailyPopUp(true));

            DateTime currentDateTime = DateTime.Now;
            UserSaveDataManager.SetEntryToDateTime(currentDateTime);

            var json = JsonParser.GetDataSet();
            Debug.Log($"{json.dataSet[0].type} / {json.dataSet[0].values}");
            */
            yield return null;
        }

        private void OnApplicationQuit()
        {
            DateTime currentDateTime = DateTime.Now;
            UserSaveDataManager.SetExitToDateTime(currentDateTime);
        }
    }
}