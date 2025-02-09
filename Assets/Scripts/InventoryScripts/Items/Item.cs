using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemScriptableObject itemScriptableObject; // Reference to the ScriptableObject

    // Event to trigger when the item is collected
    public static event System.Action<ItemScriptableObject> OnItemCollected;

    public void Start()
    {
        // Check if itemScriptableObject is assigned and ensure functionality is set
        if (itemScriptableObject != null)
        {
            // Ensure that functionality is assigned if it's null
            if (itemScriptableObject.functionality == null)
            {
                itemScriptableObject.functionality = new RestoreHealthAndHunger(); // Assign default functionality
                Debug.Log($"Default functionality assigned to item: {itemScriptableObject.itemName}");
            }
        }
        else
        {
            Debug.LogError("ItemScriptableObject is not assigned.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Item collected: {itemScriptableObject.itemName}");
            OnItemCollected?.Invoke(itemScriptableObject);
            Destroy(gameObject); // Destroy the item after collection
        }
    }
}
