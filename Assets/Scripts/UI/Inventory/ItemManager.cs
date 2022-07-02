using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "InventorySystem/Inventory")]
public class ItemManager : ScriptableObject
{
    public List<InventorySlot> inventoryItems = new List<InventorySlot>();

    public void AddItem(ItemData item, int amount)
    {
        bool hasItem = false;
        
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (inventoryItems[i].Item == item)
            {
                inventoryItems[i].AddAmount(amount);
                hasItem = true;
                break;
            }
        }

        if (!hasItem)
        {
            inventoryItems.Add(new InventorySlot(item, amount));
        }
    }

    public void RemoveItem(InventorySlot itemSlot)
    {

        //Remove item if player has it (not used so no need to make it work)

        inventoryItems.Remove(itemSlot);
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemData Item;
    public int Amount;

    public InventorySlot(ItemData item, int amount)
    {
        Item = item;
        Amount = amount;
    }

    public void AddAmount(int value)
    {
        Amount += value;
    }
    
    public void RemoveAmount(int value)
    {
        Amount -= value;
    }
}
