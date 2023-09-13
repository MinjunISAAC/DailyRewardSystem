// ----- Unity
using UnityEngine;
using UnityEngine.UI;

// ----- User Defined
using Utility.ForData.ForJson;
using Utility.ForAsset;
using Utility.ForData.User;
using InGame.DailySystem.ForUI;
using InGame.DailySystem.ForData.Helper;
using UnityEditor;

namespace InGame.DailySystem.ForManage
{
    public class DailyRewardSystem : MonoBehaviour
    {
        // --------------------------------------------------
        // Singleton
        // --------------------------------------------------
        // ----- Constructor
        private DailyRewardSystem() { }

        // ----- Static Variables
        private static DailyRewardSystem _instance = null;

        // ----- Variables
        private const string FILE_PATH = "Assets/Utility/DailyRewardSystem/Prefabs/DailyRewardSystem.prefab";
        private bool _isSingleton = false;

        // ----- Property
        public static DailyRewardSystem Instance
        {
            get
            {
                if (null == _instance)
                {
                    var existingInstance = FindObjectOfType<DailyRewardSystem>();

                    if (existingInstance != null)
                    {
                        _instance = existingInstance;
                    }
                    else
                    {
                        var origin = AssetDatabase.LoadAssetAtPath<DailyRewardSystem>(FILE_PATH);
                        _instance = Instantiate<DailyRewardSystem>(origin);
                        _instance._isSingleton = true;
                        DontDestroyOnLoad(_instance.gameObject);
                    }
                }

                if (null == _instance)
                    _instance = new DailyRewardSystem();

                return _instance;
            }
        }

        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private DailyPopUpView _dailyPopUpView = null;
        [SerializeField] private Button         _BTN_dailyPopUp = null;
        [SerializeField] private Animation      _animation      = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private DailyRewardDataHelper _dailyRewardDataHelper = null;

        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Awake()
        {
            if (null == _instance)
            {
                var existingInstance = FindObjectOfType<DailyRewardSystem>();

                if (existingInstance != null)
                {
                    _instance = existingInstance;
                    DontDestroyOnLoad(_instance.gameObject);
                }
            }

            if (_dailyRewardDataHelper == null)
                _dailyRewardDataHelper = new DailyRewardDataHelper();

            _BTN_dailyPopUp.onClick.AddListener(() => VisiableDailyPopUp(true));
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit()
        {
            UserSaveDataManager.Load();

            var datas = JsonParser.GetDataSet();

            _dailyPopUpView.OnInit();
            _dailyPopUpView.SetToRewardItems(datas, _Reward);
        }

        public void VisiableDailyPopUp(bool isShow) 
        {
            _dailyPopUpView.gameObject.SetActive(isShow);

            if (isShow) _animation.Play();
        } 
       
        public void VisiableDailyPopUpBtn(bool isShow) => _BTN_dailyPopUp.gameObject.SetActive(isShow);
        private void _Reward(EAssetType assetType, int cost)
        {
            switch (assetType)
            {
                case EAssetType.Coin: 
                    UserSaveDataManager.AddCoin(cost);
                    break;

                case EAssetType.Gem: 
                    UserSaveDataManager.AddGem(cost);
                    break;
            }

            UserSaveDataManager.SetAcquiredItemIndex();
        }
    }
}