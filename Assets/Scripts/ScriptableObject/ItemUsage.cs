using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUsage : MonoBehaviour
{
    public ItemScriptableObject item;

    private void Start()
    {
        // Assign functionality dynamically
        IItemFunctionality functionality = new RestoreHealthAndHunger();
        item.SetFunctionality(functionality);

        // Use the item
        item.UseItem(GameObject.Find("Player"));
    }
}

