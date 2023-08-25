// ----- Unity
using UnityEngine;
using Utility.ForData.User;

namespace Utility.ForAsset.ForUI
{
    public class AssetHubSystem : MonoBehaviour
    {
        // --------------------------------------------------
        // Singleton
        // --------------------------------------------------
        // ----- Constructor
        private AssetHubSystem() { }

        // ----- Static Variables
        private static AssetHubSystem _instance = null;

        // ----- Property
        public static AssetHubSystem Instance
        {
            get
            {
                if (null == _instance)
                    _instance = new AssetHubSystem();

                return _instance;
            }
        }

        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("Asset View Group")]
        [SerializeField] private AssetView _coinView = null;
        [SerializeField] private AssetView _gemView  = null;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Awake()
        {
            DontDestroyOnLoad(this);

            // User Save Data Load
            UserSaveDataManager.Load();
            var userData = UserSaveDataManager.UserSaveData;

            OnInit(userData.UserCoin, userData.UserGem);
        }

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

            _coinView.RefreshAssetValue(coinValue);
            _gemView. RefreshAssetValue(gemValue);
        }

        public void RefreshAsset()
        {
            _coinView.RefreshAssetValue(UserSaveDataManager.UserSaveData.UserCoin);
            _gemView.RefreshAssetValue(UserSaveDataManager.UserSaveData.UserGem);
        }
    }
}