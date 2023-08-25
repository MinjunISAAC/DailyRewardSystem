// ----- C#
using System.Collections.Generic;

namespace InGame.DailySystem.ForData
{
    [System.Serializable]
    public class Data
    {
        public string type;
        public int[] values;
    }

    [System.Serializable]
    public class DailyRewardData
    {
        public List<Data> dataSet = new List<Data>();
    }
}