using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private GameObject inventory, tabInventory, tabBody, tabCollectibles;
    private Animator itemInventoryAnim;

    [SerializeField] private int currentTab; //0 - Inventory/ 1 - Body/ 2 - Collectibles

    [SerializeField] private PlayerActions playerActionsScript;
    [SerializeField] private GameObject InventoryBase;
    [SerializeField] private InventoryFadeAnimation inventoryFadeAnimation;
    

    [Header("ItemTab")] 
    [SerializeField] private bool canSwitchItems = true;

    private bool isHoldingNextItemButton;
    private bool isHoldingPreviousItemButton;
    private static readonly int Next = Animator.StringToHash("Next");
    private static readonly int Previous = Animator.StringToHash("Previous");
    [SerializeField] private DisplayInventoryItems displayInventoryItems;
    public ItemData CurrentItem;


    private void Awake()
    {
        itemInventoryAnim = tabInventory.GetComponent<Animator>();
    }

    public void OpenInventory()
    {
        if (inventory.activeSelf) return;
        
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_Inventory_Open");
        displayInventoryItems.UpdateItems();
        inventory.SetActive(true);
        PauseGame.IsGamePaused = true;
        ToggleTabs(0, false); //Inventory by default
        Time.timeScale = 0;
        playerActionsScript.PlayerToInventory(true);
    }

    public void CloseInventory()
    {
        if (!InventoryBase.activeSelf) return; //Prevent actions whilst in animation
        
        
        FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_Inventory_Close");
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
    private void ToggleTabs(int tab, bool playSfx)
    {
        isHoldingNextItemButton = false;
        isHoldingPreviousItemButton = false;
        if (playSfx)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_Inventory_SwapTab");
        }
        
        if (tab == 0) //inventory
        {
            displayInventoryItems.UpdateItems();
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
            ToggleTabs(1, true);
        }
        else if (currentTab == 1)
        {
            ToggleTabs(2, true);
        }
        else if(currentTab == 2)
        {
            ToggleTabs(0, true);
        }
    }

    public void PreviousTab()
    {
        if (!InventoryBase.activeSelf) return; //Prevent actions whilst in animation
        
        if (currentTab == 0)
        {
            ToggleTabs(2, true);
        }
        else if (currentTab == 1)
        {
            ToggleTabs(0, true);
        }
        else if(currentTab == 2)
        {
            ToggleTabs(1, true);
        }
    }
    
    //InventoryTab items
    
    private IEnumerator EnableNextItemSwitch() //PreventSpam
    {
        while (isHoldingNextItemButton)
        {
            if (currentTab != 0) yield break;
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_Inventory_SwapItem");
            canSwitchItems = false;
            itemInventoryAnim.SetTrigger(Next);
            //Item Logic
            yield return new WaitForSecondsRealtime(.55f);
            canSwitchItems = true; 
        }
        
    }
    public void NextItem()
    {
        isHoldingNextItemButton = true;
        if ((!canSwitchItems && currentTab == 0) || !displayInventoryItems.CanSwapItems) return; //Reset after animation CHANGE LATER IF GAME GOES FORWARD TO A SEPARATE FUNCTION FOR ALL THE DIFFERENT TABS
        
        StartCoroutine(EnableNextItemSwitch());
    }

    public void OnNextItemRelease()
    {
        
        isHoldingNextItemButton = false;
    }
    
    private IEnumerator EnablePreviousItemSwitch() //PreventSpam
    {
        while (isHoldingPreviousItemButton)
        {
            if (currentTab != 0) yield break;
            FMODUnity.RuntimeManager.PlayOneShot("event:/UI/sfx_Inventory_SwapItem");
            canSwitchItems = false;
            itemInventoryAnim.SetTrigger(Previous);
            //Item Logic
            yield return new WaitForSecondsRealtime(.55f);
            canSwitchItems = true; 
        }
        
    }
    public void PreviousItem()
    {
        isHoldingPreviousItemButton = true;
        if ((!canSwitchItems && currentTab == 0) || !displayInventoryItems.CanSwapItems) return; //Reset after animation CHANGE LATER IF GAME GOES FORWARD TO A SEPARATE FUNCTION FOR ALL THE DIFFERENT TABS

        
        StartCoroutine(EnablePreviousItemSwitch());
    }

    public void OnPreviousItemRelease()
    {
        isHoldingPreviousItemButton = false;
    }
    
}
