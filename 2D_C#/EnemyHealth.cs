using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {


    public int enemyHealth;
   // public int pointToGive;
    public GameObject deathEffect;
    public EnemyController enemy;

    //public int pointsOnDeath;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(enemyHealth <= 0)
        {
            //Score.score += pointToGive;
            Destroy();
        }
	}

    void Destroy()
    {
        Instantiate(deathEffect, enemy.transform.position, Quaternion.identity);
        DestroyImmediate(gameObject, true);
        
    }

    public void giveDamage (int damageToGive)
    {
        enemyHealth -= damageToGive;
        
    }
}
