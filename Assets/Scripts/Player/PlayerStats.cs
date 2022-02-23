using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Stores all the stats so they are easy to use in the scripts
    public bool CanMove = true;
    
    public float PlayerFowardMovementSpeed = 9.1f;

    public int playerHp = 100;

    public bool IsInInteractionZone = false;

    [HideInInspector] public GameObject CurrentInteractionGameObject;
}
