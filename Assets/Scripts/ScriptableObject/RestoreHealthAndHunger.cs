using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreHealthAndHunger : IItemFunctionality
{
    public void Execute(GameObject player, float amount)
    {
        var playerHunger = player.GetComponent<PlayerHunger>();
        if (playerHunger != null)
        {
            Debug.Log("Restore function being called");
            playerHunger.RestoreHealthAndHunger(amount);
        }
        else Debug.Log("Player hunger not found");
    }
}
