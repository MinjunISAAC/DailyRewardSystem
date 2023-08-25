// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForData.ForJson;

namespace InGame.DailySystem.ForData.Helper
{
    public class DailyRewardDataHelper
    {
        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private DailyRewardData _dailyReardData = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public DailyRewardData GetDailyRewardData(int idx)
        {
            if (_dailyReardData == null)
                _dailyReardData = JsonParser.GetDataSet();

            return _dailyReardData;
        }
    }
}