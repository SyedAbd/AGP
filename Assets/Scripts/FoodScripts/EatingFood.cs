using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatingFood : MonoBehaviour
{
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHunger playerEating = other.GetComponent<PlayerHunger>();
            if (playerEating != null)
            {
                Debug.Log("Player is eating \n");
                //playerEating.Eat();
                //playerEating.RestoreHealthAndHunger();
                Destroy(gameObject); 
            }
        }
    }
}


