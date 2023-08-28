#if UNITY_EDITOR
// ----- C#
using System.Collections;
using System.Collections.Generic;
using System.IO;

// ----- Unity
using UnityEditor;
using UnityEngine;

namespace Utility.ForAsset
{
    public class AssetHubGenerater : MonoBehaviour
    {
        // --------------------------------------------------
        // Components
        // --------------------------------------------------
        [SerializeField] private AssetHubSystem _assetHubSystem = null;

        // --------------------------------------------------
        // Variables
        // --------------------------------------------------
        private const string FILE_PATH = "Utility/AssetHub/Prefabs/AssetHubSystem.prefab";

        [ContextMenu("AssetHubGenerater/Created AssetHubSystem")]
        private void CreateAssetHubSystemPrefab()
        {
            string filePath     = Path.Combine(Application.dataPath, FILE_PATH);

            if (File.Exists(filePath)) 
                File.Delete(filePath);

            GameObject copiedPrefab = PrefabUtility.InstantiatePrefab(_assetHubSystem.gameObject) as GameObject;

            PrefabUtility.SaveAsPrefabAsset(copiedPrefab, filePath);
            DestroyImmediate(copiedPrefab);
        }
    }
}
#endif