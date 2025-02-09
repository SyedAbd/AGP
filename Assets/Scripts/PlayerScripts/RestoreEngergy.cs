using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestoreEnergy : IItemFunctionality
{
    public void Execute(GameObject player, float amount)
    {
        var playerHunger = player.GetComponent<PlayerHealth>();
        if (playerHunger != null)
        {
            Debug.Log("Restore health function being called");
            playerHunger.Restore(amount);
        }
        else Debug.Log("Player hunger not found");
    }
}
