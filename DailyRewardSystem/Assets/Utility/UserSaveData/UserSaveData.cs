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
        [Header("���� ���� ����")]
        [SerializeField] private DateTime _entryDataTime         = default;
        [SerializeField] private DateTime _exitDataTime          = default;

        [Space(1.5f)] [Header("��ȭ")]
        [SerializeField] private int      _userCoin              = 0;
        [SerializeField] private int      _userGem               = 0;

        [Space(1.5f)] [Header("ȹ�� ����")]
        [SerializeField] private int      _lastAcquiredItemIndex = 0;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        // ----- DataTime
        public DateTime EntryDataTime => _entryDataTime;
        public DateTime ExitDataTime  => _exitDataTime;

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
                case EAssetType.Gem:  _userGem  += assetValue;  break;
            }
        }

        public void ConsumeAsset(EAssetType type, int assetValue)
        {
            switch (type)
            {
                case EAssetType.Coin:
                    if (_userCoin < assetValue)
                    {
                        // [TODO] Toast �޼��� �ʿ���.
                        return;
                    }

                    _userCoin -= assetValue; 
                    break;

                case EAssetType.Gem:
                    if (_userGem < assetValue)
                    {
                        // [TODO] Toast �޼��� �ʿ���.
                        return;
                    }

                    _userGem -= assetValue;
                    break;
            }
        }
    }
}