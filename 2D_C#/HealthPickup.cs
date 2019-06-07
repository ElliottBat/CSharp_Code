using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour {


    public int giveHealth;
    public PlayerHealth player;
    public int pointGain = 20;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerHealth>().giveHealth(giveHealth);
            Score.score += pointGain;
        }

        Destroy(gameObject);

    }
}
