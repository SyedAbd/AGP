using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHunger : MonoBehaviour
{
    private PlayerHealth playerHealth; 
    private float timeSinceLastMeal = 0f;
    [SerializeField] private float hungerTimer = 300f;
    //[SerializeField] private float restoreHealth = 30f;
    [SerializeField] private Image HungerBar;

    void Start()
    {
        
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        
        timeSinceLastMeal += Time.deltaTime;

        //Debug.Log("Time passed "+ timeSinceLastMeal+"\n");
        if (timeSinceLastMeal >= hungerTimer)
        {
            Debug.Log("Started health Decay \n");
            playerHealth.StartHealthDecay();
        }
    }
    private void FixedUpdate()
    {
        HungerBar.fillAmount =  ((hungerTimer - timeSinceLastMeal) / hungerTimer);
    }
    public void RestoreHealthAndHunger(float restoreHealth)
    {
        Debug.Log("Restoring health and hunger");
        Eat();
        playerHealth.Restore(restoreHealth);
    }
    public void Eat()
    {
        Debug.Log("Started eating and health decay stoppping \n ");
        timeSinceLastMeal = 0f;
        playerHealth.StopHealthDecay(); 
    }
}
