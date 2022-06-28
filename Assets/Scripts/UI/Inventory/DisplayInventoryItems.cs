using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventoryItems : MonoBehaviour
{
    public ItemManager PlayerInventory;

    [SerializeField] private Image currentItem, itemRight, itemLeft;
    public bool CanSwapItems;

    private void Awake()
    {
        UpdateItems();
    }

    public void UpdateItems()
    {
        if (PlayerInventory.inventoryItems.Count == 0)
        {
            CanSwapItems = false;
            ToggleItemSprites(false);
        }
        
        else if (PlayerInventory.inventoryItems.Count == 1)
        {
            CanSwapItems = false;
            currentItem.enabled = true;
            currentItem.sprite = PlayerInventory.inventoryItems[0].Item.Icon;
        }
        else if (PlayerInventory.inventoryItems.Count == 2)
        {
            CanSwapItems = true;
            ToggleItemSprites(true);
        }
    }

    private void ToggleItemSprites(bool toggle)
    {
        if (toggle)
        {
            currentItem.enabled = true;
            itemLeft.enabled = true;
            itemRight.enabled = true;
        }
        else
        {
            currentItem.enabled = false;
            itemLeft.enabled = false;
            itemRight.enabled = false;
        }
        
    }
}
