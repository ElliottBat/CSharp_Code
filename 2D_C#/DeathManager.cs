using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour {

    public int damageAmonut;
    public PlayerHealth player;
    public EnemyHealth enemy;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" )
        {
            other.GetComponent<PlayerHealth>().takeDamage(damageAmonut);
            Destroy(this.gameObject);

        }
        else if (other.tag == "Enemy")
        {
            other.GetComponent<EnemyHealth>().giveDamage(damageAmonut);
            Destroy(this.gameObject);
        }

    }
    
}
