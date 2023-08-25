// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using InGame.DailySystem.ForData;

namespace Utility.ForData.ForJson
{
    public static class JsonParser
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Const
        private const string JSONFILE_NAME = "[DailySystem]Sample";

        // ----- Private
        private static DailyRewardData _dataSet = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public static void LoadJson()
        {
            var loadedJsonFile = Resources.Load<TextAsset>($"JsonSet/{JSONFILE_NAME}");

            if (loadedJsonFile == null)
            {
                Debug.LogError("<color=#FF0000>[JsonParser.LoadJson] Json File이 존재하지 않습니다.</color>");
                return;
            }

            _dataSet = JsonUtility.FromJson<DailyRewardData>(loadedJsonFile.text);

            if (_dataSet == null)
            {
                Debug.LogError("<color=#FF0000>[JsonParser.LoadJson] JSON 파싱에 실패하였습니다.</color>");
                return;
            }
        }

        public static DailyRewardData GetDataSet()
        {
            if (_dataSet == null) 
                LoadJson();

            return _dataSet;
        }
    }
}