using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUseItem : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private PlayerStats playerStatsScript;
    [SerializeField] private DisplayInventoryItems displayItems;
    [SerializeField] private ItemManager inventory;
    [SerializeField] private Animator cannotAnim;
    private static readonly int Cannot = Animator.StringToHash("Cannot");

    private void Awake()
    {
        inventoryManager = GetComponent<InventoryManager>();
        playerStatsScript = FindObjectOfType<PlayerStats>();
    }

    public void UseItem()
    {

        if (playerStatsScript.CurrentItemUse == null)
        {
            if (displayItems.HasItemInInventory)
            {
                cannotAnim.SetTrigger(Cannot);
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_Inventory_UseItemFail");
            }
            
            //Wrong use sound
            return;
        }

        
        if (inventoryManager.CurrentItem == null)
        {
            //Cant be used Message (No items in inventory)
            return;
        }
        else
        {
            if (playerStatsScript.CurrentItemUse.CheckForItem(inventoryManager.CurrentItem.Id))
            {
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_Inventory_UseItem");
                //Remove item from inventory
                var itemToRemove = 0;
                
                //Hard Coded because there are only two items
                if (inventory.inventoryItems[0].Item.Id != inventoryManager.CurrentItem.Id)
                {
                    itemToRemove = 1;
                }

                if (inventory.inventoryItems.Count > 0)
                {
                    inventory.RemoveItem(inventory.inventoryItems[itemToRemove]);
                    inventoryManager.CurrentItem = null;
                }
                
                inventoryManager.CloseInventory();
            }
            else
            {
                //Cant be used Message (Using incorrect item)
                cannotAnim.SetTrigger(Cannot);
                FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_Inventory_UseItemFail");
                return;
            }
           
        }
    }
}
