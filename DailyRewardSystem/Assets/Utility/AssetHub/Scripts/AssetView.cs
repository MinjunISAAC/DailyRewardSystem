// ----- C#
using System;

// ----- Unity
using UnityEngine;
using TMPro;

namespace Utility.ForAsset.ForUI
{
    public class AssetView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private EAssetType      _assetType = EAssetType.Unknown;
        [SerializeField] private TextMeshProUGUI _TMP_value = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        // ----- Public
        public void RefreshAssetValue(int value)
        {
            _TMP_value.text = _FormatAssetValue(value);
        }

        // ----- Private
        private string _FormatAssetValue(int value)
        {
            string formattedValue = $"{value:0.##}";

            if (value >= 1000)
            {
                int orderOfMagnitude = (int)Math.Floor(Math.Log10(value));
                
                if      (orderOfMagnitude >= 3 && orderOfMagnitude < 6)  formattedValue = $"{(value / 1000.0):0.##}K";
                else if (orderOfMagnitude >= 6 && orderOfMagnitude < 9)  formattedValue = $"{(value / 1000000.0):0.##}M";
                else if (orderOfMagnitude >= 9 && orderOfMagnitude < 12) formattedValue = $"{(value / 1000000000.0):0.##}G";
                else                                                     formattedValue = $"MAX";
            }

            return formattedValue;
        }
    }
}