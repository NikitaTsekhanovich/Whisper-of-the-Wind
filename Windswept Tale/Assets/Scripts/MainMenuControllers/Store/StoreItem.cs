using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenuControllers.Store
{
    public class StoreItem : MonoBehaviour
    {
        [SerializeField] private Image _leafIcon;
        [SerializeField] private TMP_Text _priceText;
        [SerializeField] private Image _chooseMark;
        [SerializeField] private TMP_Text _buttonText;
        [SerializeField] private GameObject _priceBlock;
        private int _index;
        private Action<int> _onChooseItem;

        public void InitItem(Sprite leafIcon, int priceText, TypeItemStore typeItemStore, int index, Action<int> OnChooseItem)
        {
            _leafIcon.sprite = leafIcon;
            _index = index;
            _onChooseItem = OnChooseItem;
            _priceText.text = $"{priceText}";
            
            ChangeStateItem(typeItemStore);
        }

        public void ChangeStateItem(TypeItemStore typeItemStore)
        {   
            if (typeItemStore == TypeItemStore.Selected)
            {
                _chooseMark.enabled = true;
                _priceBlock.SetActive(false);
                _buttonText.text = "";
            }
            else if (typeItemStore == TypeItemStore.Bought)
            {
                _chooseMark.enabled = false;
                _priceBlock.SetActive(false);
                _buttonText.text = $"Select";
            }
            else if (typeItemStore == TypeItemStore.NotBought) 
            {
                _chooseMark.enabled = false;
                _buttonText.text = $"Buy";
            }
        }

        public void ChooseItem()
        {
            _onChooseItem.Invoke(_index);
        }
    }
}

