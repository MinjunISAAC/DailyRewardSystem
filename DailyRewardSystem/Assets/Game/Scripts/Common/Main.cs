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
            
            // Daily System Init
            DailyRewardSystem.Instance.OnInit();

            Debug.Log($"User Data {userData.EntryDataTime} / {userData.ExitDataTime} / {userData.FirstEntry}");
            
            DateTime currentDateTime = DateTime.Now;
            UserSaveDataManager.SetEntryToDateTime(currentDateTime);
            
            if (userData.FirstEntry) DailyRewardSystem.Instance.VisiableDailyPopUp(true);
            else                     DailyRewardSystem.Instance.VisiableDailyPopUp(false);


            // Static Manage Init
            //AssetManager.SetAssetHubView(assetHubView);


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