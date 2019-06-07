using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float moveSpeed;
    Rigidbody2D myRb;
    public bool moveRight;

    public PlayerHealth player;
    public int damageToGive;

    public Transform WallCheck;
    public float WallCheckRadius;
    public LayerMask isWall;
    private bool hittingWall;

    // Use this for initialization
    void Start () {
        myRb = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update () {

        hittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, isWall);

        if (hittingWall)
        {
            moveRight = !moveRight;
        }
        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            myRb.velocity = new Vector2(moveSpeed, myRb.velocity.y);
        }
        else 
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            myRb.velocity = new Vector2(-moveSpeed, myRb.velocity.y);
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag == "Player")
       {
           other.GetComponent<PlayerHealth>().takeDamage(damageToGive); 
        }
   }
  
}
