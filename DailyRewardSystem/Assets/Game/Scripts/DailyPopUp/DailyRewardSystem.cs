// ----- Unity
using UnityEngine;
using UnityEngine.UI;

// ----- User Defined
using Utility.ForData.ForJson;
using Utility.ForAsset;
using Utility.ForData.User;
using InGame.DailySystem.ForUI;
using InGame.DailySystem.ForData.Helper;

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

        // ----- Property
        public static DailyRewardSystem Instance
        {
            get
            {
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

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private DailyRewardDataHelper _dailyRewardDataHelper = null; 
        
        // --------------------------------------------------
        // Functions - Event
        // --------------------------------------------------
        private void Awake() 
        { 
           DontDestroyOnLoad(this);

            if (_dailyRewardDataHelper == null)
                _dailyRewardDataHelper = new DailyRewardDataHelper();

            _BTN_dailyPopUp.onClick.AddListener(() => VisiableDailyPopUp(true));
            OnInit();
        }

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInit() 
        { 
            var datas = JsonParser.GetDataSet();
            
            _dailyPopUpView.OnInit();
            _dailyPopUpView.SetToRewardItems(datas, _Reward);
        }

        public void VisiableDailyPopUp(bool isShow)    => _dailyPopUpView.gameObject.SetActive(isShow);
        public void VisiableDailyPopUpBtn(bool isShow) => _BTN_dailyPopUp.gameObject.SetActive(isShow);
        private void _Reward(EAssetType assetType, int cost) 
        {
            switch (assetType) 
            {
                case EAssetType.Coin: UserSaveDataManager.AddCoin(cost); break;
                case EAssetType.Gem:  UserSaveDataManager.AddGem (cost); break;
            }
        }
    }
} 