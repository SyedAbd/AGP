using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSleep : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private float timeSinceLastSleep = 0f;  // Time since the player last slept
    [SerializeField] private float sleepTimer = 200f;  // Time threshold for sleep deprivation effects (10 minutes)
    [SerializeField] private float restoreHealth = 50f;  // Health restored when the player sleeps
    [SerializeField] private Image SleepBar;  // UI element for displaying sleep status

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();  // Get the PlayerHealth component from the player
    }

    void Update()
    {
        // Increment the time since the last sleep
        timeSinceLastSleep += Time.deltaTime;

        // If the time since the last sleep reaches the threshold, start health decay
        if (timeSinceLastSleep >= sleepTimer)
        {
            Debug.Log("Player is sleep deprived! Starting health decay...");
            playerHealth.StartHealthDecay();
        }
    }

    private void FixedUpdate()
    {
        // Update the SleepBar fill amount based on the time since the last sleep
        SleepBar.fillAmount =  ((sleepTimer -timeSinceLastSleep) / sleepTimer);
    }

    public void Sleep()
    {
        Debug.Log("Player is sleeping. Health decay stopping and health being restored.");
        timeSinceLastSleep = 0f;  // Reset the timer after the player sleeps
        playerHealth.StopHealthDecay();  // Stop health decay
        RestoreHealth();  // Restore health after sleep
    }

    public void RestoreHealth()
    {
        playerHealth.Restore(restoreHealth);  // Restore a fixed amount of health
        Debug.Log("Health restored by " + restoreHealth);
    }
}
