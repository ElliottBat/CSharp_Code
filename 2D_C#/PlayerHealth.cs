using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    /// <summary>
    /// Must Have Healthbar Ui Setup
    /// </summary>
    
    public int startHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public GameObject deathEffect;
    public PlayerController player;
    private LifeManager liveSystem;

	// Use this for initialization
	void Start () {
        currentHealth = startHealth;
        liveSystem = FindObjectOfType<LifeManager>();
	}
    private void Update()
    {
        //Use to test heathbar code
        //Must remove on final build!!
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            takeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            giveHealth(10);
        }
    }
    // Must be called in order to take heath from player.
    public void takeDamage(int amount)
    {
        currentHealth -= amount;
        healthSlider.value = currentHealth;
        if(currentHealth <= 0)
        {
            
            Instantiate(deathEffect, player.transform.position, Quaternion.identity);
            liveSystem.takeLife();
            Dead();
        }
    }
    //This must called in Health Pickup to give player health.
    public void giveHealth(int Give)
    {
        currentHealth += Give;
        healthSlider.value = currentHealth;
        
    }
    void Dead()
    {
        
        Destroy(this.gameObject);
            
    }
}
