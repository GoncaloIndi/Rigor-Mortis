using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //Stores all the stats so they are easy to use in the scripts
    public bool CanMove = true;

    public bool IsOnTargetLockOn = false;
    
    public float PlayerFowardMovementSpeed = 9.1f;

    public int PlayerHp = 100;

    public bool IsInInteractionZone = false;

    [HideInInspector] public GameObject CurrentInteractionGameObject;

    public void DamagePlayer(int dmg)
    {
        PlayerHp -= dmg;
        if (PlayerHp <= 0)
        {
            Debug.Log("Death");
        }
    }
}
