using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MainMenuControllers.Store
{
    public class SkinsDataContainer : MonoBehaviour
    {
        public static List<StoreItemData> SkinsData { get; private set; }

        public static void LoadSkinsData()
        {
            SkinsData = Resources.LoadAll<StoreItemData>("ScriptableObjectSkinsData")
                .OrderBy(x => x.Index)
                .ToList();
        }
    }
}

