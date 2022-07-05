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
    [SerializeField] private Text itemNameDisplay;
    [SerializeField] private Text itemDescriptionDisplay;
    [SerializeField] private GameObject useItemIcon;

    private Sprite currentHolder, nextHolder;

    private void Awake()
    {
        UpdateItems();
    }

    public void UpdateItems()
    {
        if (PlayerInventory.inventoryItems.Count == 0) //No items
        {
            itemNameDisplay.text = "";
            itemDescriptionDisplay.text = "";
            CanSwapItems = false;
            ToggleItemSprites(false);
            useItemIcon.SetActive(false);
        }
        
        else if (PlayerInventory.inventoryItems.Count == 1) //One item 
        {
            CanSwapItems = false;
            currentItem.enabled = true;
            itemLeft.enabled = false;
            itemRight.enabled = false;
            currentItem.sprite = PlayerInventory.inventoryItems[0].Item.Icon;
            itemNameDisplay.text = PlayerInventory.inventoryItems[0].Item.Name;
            itemDescriptionDisplay.text = PlayerInventory.inventoryItems[0].Item.ExamineText;
            inventoryManager.CurrentItem = PlayerInventory.inventoryItems[0].Item;
            useItemIcon.SetActive(true);
        }
        else if (PlayerInventory.inventoryItems.Count == 2) //Two items
        {
            useItemIcon.SetActive(true);
            CanSwapItems = true;
            ToggleItemSprites(true);
            if (currentItem.sprite == PlayerInventory.inventoryItems[0].Item.Icon)
            {
                itemNameDisplay.text = PlayerInventory.inventoryItems[0].Item.Name;
                itemDescriptionDisplay.text = PlayerInventory.inventoryItems[0].Item.ExamineText;
                itemLeft.sprite = PlayerInventory.inventoryItems[1].Item.Icon;
                itemRight.sprite = PlayerInventory.inventoryItems[1].Item.Icon;
            }
            else
            {
                itemNameDisplay.text = PlayerInventory.inventoryItems[1].Item.Name;
                itemDescriptionDisplay.text = PlayerInventory.inventoryItems[1].Item.ExamineText;
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
        if (itemNameDisplay.text == PlayerInventory.inventoryItems[1].Item.Name)
        {
            itemNameDisplay.text = PlayerInventory.inventoryItems[0].Item.Name;
            itemDescriptionDisplay.text = PlayerInventory.inventoryItems[0].Item.ExamineText;
            inventoryManager.CurrentItem = PlayerInventory.inventoryItems[0].Item;

        }
        else
        {
            itemNameDisplay.text = PlayerInventory.inventoryItems[1].Item.Name;
            itemDescriptionDisplay.text = PlayerInventory.inventoryItems[1].Item.ExamineText;
            inventoryManager.CurrentItem = PlayerInventory.inventoryItems[1].Item;
        }
    }
}
