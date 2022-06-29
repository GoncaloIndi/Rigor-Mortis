using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInventoryItems : MonoBehaviour
{
    public ItemManager PlayerInventory;
    [SerializeField] private InventoryManager inventoryManager;

    [SerializeField] private Image currentItem, itemRight, itemLeft;
    public bool CanSwapItems;
    [SerializeField] private Text itemDisplay;

    private Sprite currentHolder, nextHolder;

    private void Awake()
    {
        UpdateItems();
    }

    public void UpdateItems()
    {
        if (PlayerInventory.inventoryItems.Count == 0) //No items
        {
            itemDisplay.text = "";
            CanSwapItems = false;
            ToggleItemSprites(false);
        }
        
        else if (PlayerInventory.inventoryItems.Count == 1) //One item 
        {
            CanSwapItems = false;
            currentItem.enabled = true;
            itemLeft.enabled = false;
            itemRight.enabled = false;
            currentItem.sprite = PlayerInventory.inventoryItems[0].Item.Icon;
            itemDisplay.text = PlayerInventory.inventoryItems[0].Item.name;
            inventoryManager.CurrentItem = PlayerInventory.inventoryItems[0].Item;

        }
        else if (PlayerInventory.inventoryItems.Count == 2) //Two items
        {
            CanSwapItems = true;
            ToggleItemSprites(true);
            if (currentItem.sprite == PlayerInventory.inventoryItems[0].Item.Icon)
            {
                itemDisplay.text = PlayerInventory.inventoryItems[0].Item.name;
                itemLeft.sprite = PlayerInventory.inventoryItems[1].Item.Icon;
                itemRight.sprite = PlayerInventory.inventoryItems[1].Item.Icon;
            }
            else
            {
                itemDisplay.text = PlayerInventory.inventoryItems[1].Item.name;
                itemLeft.sprite = PlayerInventory.inventoryItems[0].Item.Icon;
                itemRight.sprite = PlayerInventory.inventoryItems[0].Item.Icon;
            }
            
            
        }
        else //More than two items
        {
            //Wont happen if need be do later
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
    
    //Item switch (animations) temp but no need
    public void PreviousItemBegin()
    {
        currentHolder = currentItem.sprite;
        nextHolder = itemLeft.sprite;
        itemRight.sprite = currentHolder;
        ChangeCurrentItemName();
    }

    public void PreviousItemEnd()
    {
        currentItem.sprite = nextHolder;
        itemLeft.sprite = currentHolder;
    }

    public void NextItemBegin()
    {
        currentHolder = currentItem.sprite;
        nextHolder = itemRight.sprite;
        itemLeft.sprite = currentHolder;
        ChangeCurrentItemName();
    }

    public void NextItemEnd()
    {
        itemRight.sprite = currentHolder;
        currentItem.sprite = nextHolder;
    }

    private void ChangeCurrentItemName() //Stupid not supposed to be like this
    {
        if (itemDisplay.text == PlayerInventory.inventoryItems[1].Item.name)
        {
            itemDisplay.text = PlayerInventory.inventoryItems[0].Item.name;
        }
        else
        {
            itemDisplay.text = PlayerInventory.inventoryItems[1].Item.name;
        }
    }
}
