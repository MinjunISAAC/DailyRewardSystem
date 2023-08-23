// ----- C#
using System.Collections;
using System.Collections.Generic;

// ----- Unity
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace InGame.DailySystem.ForUI
{
    public class DailyItem : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private Button          _BTN_Click   = null;
        [SerializeField] private Image           _IMG_Hide    = null;
        [SerializeField] private Image           _IMG_Icon    = null;
        [SerializeField] private TextMeshProUGUI _TMP_DayText = null;

        // --------------------------------------------------
        // Functions - Nomal
        // --------------------------------------------------
        public void OnInIt()
        {
            // Button 実特 
            // Icon 実特
            // Text 実特

            // Hide Image 実特
        }
    }
}