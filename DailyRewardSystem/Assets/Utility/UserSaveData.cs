// ----- C#
using System;

// ----- Unity
using UnityEngine;

namespace Utility.ForData.User
{
    [Serializable]
    public class UserSaveData
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [Header("유저 접속 정보")]
        [SerializeField] private DateTime _entryDataTime         = default;
        [SerializeField] private DateTime _exitDataTime          = default;

        [Space(1.5f)] [Header("재화")]
        [SerializeField] private int      _userCoin              = 0;

        [Space(1.5f)] [Header("획득 정보")]
        [SerializeField] private int      _lastAcquiredItemIndex = 0;

        // --------------------------------------------------
        // Properties
        // --------------------------------------------------
        // ----- DataTime
        public DateTime EntryDataTime => _entryDataTime;
        public DateTime ExitDataTime  => _exitDataTime;

        // ----- Int
        public int UserCoin              => _userCoin;
        public int LastAcquiredItemIndex => _lastAcquiredItemIndex;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void AddCoin(int coin) => _userCoin += coin;

        public void ConsumeCoin(int coin) 
        {
            if (_userCoin < coin)
            {
                // [TODO] Toast 메세지 필요함.
                return;
            }

            _userCoin -= coin;
        }
    }
}