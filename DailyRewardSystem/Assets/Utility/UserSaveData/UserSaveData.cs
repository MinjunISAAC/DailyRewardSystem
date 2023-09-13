// ----- C#
using System;

// ----- Unity
using UnityEngine;

// ----- User Defined
using Utility.ForAsset;

namespace Utility.ForData.User
{
    [Serializable]
    public class UserSaveData
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("유저 접속 정보")]
        [SerializeField] private string   _entryDataTime         = default;
        [SerializeField] private string   _exitDataTime          = default;
        [SerializeField] private bool     _firstEntry            = true;

        [Space(1.5f)] [Header("재화")]
        [SerializeField] private int      _userCoin              = 0;
        [SerializeField] private int      _userGem               = 0;

        [Space(1.5f)] [Header("획득 정보")]
        [SerializeField] private int      _lastAcquiredItemIndex = 0;
        [SerializeField] private bool     _acquiredDailyReward   = false;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        // ----- DataTime
        public string EntryDataTime => _entryDataTime;
        public string ExitDataTime  => _exitDataTime;
        public bool   FirstEntry    => _firstEntry;

        // ----- Int
        public int UserCoin              => _userCoin;
        public int UserGem               => _userGem;
        public int LastAcquiredItemIndex => _lastAcquiredItemIndex;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void AddAsset(EAssetType type, int assetValue) 
        { 
            switch (type)
            {
                case EAssetType.Coin: _userCoin += assetValue; break;
                case EAssetType.Gem:  _userGem  += assetValue; break;
            }
        }

        public void ConsumeAsset(EAssetType type, int assetValue)
        {
            switch (type)
            {
                case EAssetType.Coin:
                    if (_userCoin < assetValue)
                    {
                        // [TODO] Toast 메세지 필요함.
                        return;
                    }

                    _userCoin -= assetValue; 
                    break;

                case EAssetType.Gem:
                    if (_userGem < assetValue)
                    {
                        // [TODO] Toast 메세지 필요함.
                        return;
                    }

                    _userGem -= assetValue;
                    break;
            }
        }

        public void SetExitToDateTime(DateTime dateTime) 
        {
            var dateTimeStr = $"{dateTime.Year}-{dateTime.Month}-{dateTime.Day}";
            _exitDataTime   = dateTimeStr;

            if (_firstEntry) // 첫번째 입장이 맞으면
            {
                if (_exitDataTime != _entryDataTime) 
                {
                    _acquiredDailyReward = false;
                    _firstEntry          = true;
                }
                else
                {
                    _firstEntry          = false;
                    _acquiredDailyReward = true;
                }
            }
        }

        public void SetEntryToDateTime(DateTime dateTime)
        {
            var dateTimeStr = $"{dateTime.Year}-{dateTime.Month}-{dateTime.Day}";
            _entryDataTime  = dateTimeStr;
        }

        public void SetAcquiredItemIndex() 
        {
            if (!_firstEntry)
                return;

            _lastAcquiredItemIndex++;
            _acquiredDailyReward = true;

            if (_lastAcquiredItemIndex == 7)
                _lastAcquiredItemIndex = 0;
        }

        public int  GetAcquiredItemIndex() => _lastAcquiredItemIndex;
        public bool GetFirstEntry()        => _firstEntry;
    }
}