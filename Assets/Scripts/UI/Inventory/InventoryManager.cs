using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory, tabInventory, tabBody, tabCollectibles;

    [SerializeField] private int currentTab; //0 - Inventory/ 1 - Body/ 2 - Collectibles

    [SerializeField] private PlayerActions playerActionsScript;
    [SerializeField] private GameObject InventoryBase;
    [SerializeField] private InventoryFadeAnimation inventoryFadeAnimation;
    
    public void OpenInventory()
    {
        if (inventory.activeSelf) return;

        inventory.SetActive(true);
        PauseGame.IsGamePaused = true;
        ToggleTabs(0); //Inventory by default
        Time.timeScale = 0;
        playerActionsScript.PlayerToInventory(true);
    }

    public void CloseInventory()
    {
        if (!InventoryBase.activeSelf) return; //Prevent actions whilst in animation
        
        inventoryFadeAnimation.TriggerFadeOut(); //Animation
        PauseGame.IsGamePaused = false;
        Time.timeScale = 1;
        playerActionsScript.PlayerToInventory(false);
    }

    public void BackInventory()
    {
        if (!InventoryBase.activeSelf) return; //Prevent actions whilst in animation
        
        CloseInventory();  
    }
    
    //Tabs
    private void ToggleTabs(int tab)
    {
        if (tab == 0) //inventory
        {
            currentTab = 0;
            tabInventory.SetActive(true);
            tabBody.SetActive(false);
            tabCollectibles.SetActive(false);
        }
        else if(tab == 1) //Body
        {
            currentTab = 1;
            tabInventory.SetActive(false);
            tabBody.SetActive(true);
            tabCollectibles.SetActive(false);
        }
        else if (tab == 2) //Collectibles 
        {
            currentTab = 2;
            tabInventory.SetActive(false);
            tabBody.SetActive(false);
            tabCollectibles.SetActive(true);
        }
        
    }

    public void NextTab()
    {
        if (!InventoryBase.activeSelf) return; //Prevent actions whilst in animation
        
        if (currentTab == 0)
        {
            ToggleTabs(1);
        }
        else if (currentTab == 1)
        {
            ToggleTabs(2);
        }
        else if(currentTab == 2)
        {
            ToggleTabs(0);
        }
    }

    public void PreviousTab()
    {
        if (!InventoryBase.activeSelf) return; //Prevent actions whilst in animation
        
        if (currentTab == 0)
        {
            ToggleTabs(2);
        }
        else if (currentTab == 1)
        {
            ToggleTabs(0);
        }
        else if(currentTab == 2)
        {
            ToggleTabs(1);
        }
    }
}
