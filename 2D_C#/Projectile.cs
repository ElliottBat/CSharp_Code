using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Damage = 10;
    public float fireSpeed = 10f;
    public int damageToGive;
    Rigidbody2D myRb;
    private PlayerController player;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController>();

        myRb = GetComponent<Rigidbody2D>();

        if (player.transform.localScale.x > 0)
        { 
            fireSpeed = -fireSpeed;
        }else if(player.transform.localScale.x < 0)
        {
            myRb.velocity = new Vector2(fireSpeed, myRb.velocity.y);
        }
	}
	
	// Update is called once per frame
	void Update () {
        myRb.velocity = new Vector2(fireSpeed, myRb.velocity.y);
        Destroy();
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().giveDamage(damageToGive);
        }

        Destroy(gameObject);
        
    }
    void Destroy()
    {
        Destroy(gameObject, 2); 
    }
}
