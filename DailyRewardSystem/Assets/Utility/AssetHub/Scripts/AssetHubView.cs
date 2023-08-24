// ----- Unity
using UnityEngine;


namespace Utility.ForAsset.ForUI
{
    public class AssetHubView : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Asset View Group")]
        [SerializeField] private AssetView _coinView = null;
        [SerializeField] private AssetView _gemView = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit(int coinValue, int gemValue)
        {
            if (_coinView == null || _gemView == null)
            {
                Debug.LogError($"<color=red>[AssetHubView.OnInit] Asset들의 View가 존재하지 않는 View가 존재합니다.</color>");
                return;
            }

            _coinView.OnInit(coinValue);
            _gemView. OnInit(gemValue);
        }
    }
}