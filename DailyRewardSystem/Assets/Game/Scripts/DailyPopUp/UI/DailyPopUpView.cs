// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;

namespace InGame.DailySystem.ForUI
{
    public class DailyPopUpView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("UI Components")]
        [SerializeField] private Button    _BTN_Close   = null;
        [SerializeField] private Transform _itemParents = null;

        [Space(1.5f)] [Header("Item Prefab")]
        [SerializeField] private DailyItem _dailyItem   = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Data

        // ----- UI
        private List<DailyItem> _itemSet = new List<DailyItem>();

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void CreateItem()
        {

        }
    }
}