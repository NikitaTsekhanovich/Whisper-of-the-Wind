using UnityEngine;

namespace MainMenuControllers.Store
{
    [CreateAssetMenu(fileName = "StoreItemData", menuName = "Store item data/ Store item")]
    public class StoreItemData : ScriptableObject
    {
        [SerializeField] private int _index;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _price;

        public int Index => _index;
        public Sprite Icon => _icon;
        public int Price => _price;
        public TypeItemStore TypeState
        {
            get
            {
                return (TypeItemStore)PlayerPrefs.GetInt($"{StoreDataKeys.StateItemKey}{_index}");
            }
        }
    }
}

