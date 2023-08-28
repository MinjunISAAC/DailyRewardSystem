// ----- C#
using System.IO;

// ----- Unity
using UnityEngine;
using UnityEditor;

// ----- User Defined
using Utility.ForAsset.ForUI;
using Utility.ForData.User;

namespace Utility.ForAsset
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

        // ----- Variables
        private const string FILE_PATH = "Assets/Utility/AssetHub/Prefabs/AssetHubSystem.prefab";
        private bool _isSingleton = false;

        // ----- Property
        public static AssetHubSystem Instance
        {
            get
            {
                if (null == _instance)
                {
                    var existingInstance = FindObjectOfType<AssetHubSystem>();

                    if (existingInstance != null)
                    {
                        _instance = existingInstance;
                    }
                    else
                    {
                        var origin = AssetDatabase.LoadAssetAtPath<AssetHubSystem>(FILE_PATH);
                        _instance = Instantiate<AssetHubSystem>(origin);
                        _instance._isSingleton = true;
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                }

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
            // User Save Data Load
            UserSaveDataManager.Load();
            var userData = UserSaveDataManager.UserSaveData;

            if (null == _instance)
            {
                var existingInstance = FindObjectOfType<AssetHubSystem>();

                if (existingInstance != null)
                {
                    _instance = existingInstance;
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }

            OnInit(userData.UserCoin, userData.UserGem);
        }

        private void OnDestroy()
        {
            if (_isSingleton)
                _instance = null;
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