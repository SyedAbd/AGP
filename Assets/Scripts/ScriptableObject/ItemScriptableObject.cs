using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;





[CreateAssetMenu(fileName = "ItemSO", menuName = "Inventory/ItemSO")]
public class ItemScriptableObject : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite icon;
    public int quantity;
    public float changeStatsByThisAmount;

    [SerializeField]
    public IItemFunctionality functionality;
    public void SetFunctionality(IItemFunctionality newFunctionality)
    {
        functionality = newFunctionality;
    }
    public void SetFunctionality(string typeOfFunc)
    {
       
        
        if (typeOfFunc == "HealthandHunger")
        {
            functionality = new RestoreHealthAndHunger();
        }
        else if (typeOfFunc == "HealthItem")
        {
            functionality = new RestoreEnergy();
        }
    }
    public void UseItem(GameObject player)
    {
        if (functionality != null)
        {
            Debug.Log($"Using item: {itemName} with assigned functionality.");
            functionality.Execute(player, changeStatsByThisAmount);
        }
        else
        {
            Debug.LogError($"Functionality not assigned for item: {itemName}");
        }
    }
}
































//[CreateAssetMenu(fileName = "ItemSO", menuName = "Inventory/ItemSO")]
//public class ItemScriptableObject : ScriptableObject
//{

//    public string itemName;
//    public string description;
//    public Sprite icon;
//    public int quantity;
//    public FunctionOfSO functionToPerform = new FunctionOfSO();
//    public float changeStatsByThisAmount;

//    public void UseItem()
//    {

//        if (functionToPerform == FunctionOfSO.hungerAndHealth)
//        {
//            GameObject.Find("Player").GetComponent<PlayerHunger>().RestoreHealthAndHunger(changeStatsByThisAmount);
//        }


//    }
//    public enum FunctionOfSO
//    {
//        none,
//        health,
//        sleep,
//        hunger,
//        hungerAndHealth,
//        sleepAndHealth,
//    };
//}












