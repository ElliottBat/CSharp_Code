using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    /// <summary>
    /// Must need Rigidbody2d.
    /// </summary>

    public float moveSpeed;
    Rigidbody2D myRb;
    bool faceRight;

    public float jumpHeight;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask isGround;
    private bool grounded;

    public GameObject projectile;
    public Transform firePoint;
   



    // Use this for initialization
    void Start () {
        
        myRb = GetComponent<Rigidbody2D>();
	}

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);
    }

    // Update is called once per frame
    void Update () {
        // Junping Code
        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            myRb.velocity = new Vector2(0, jumpHeight);
        }
        

        //Moving left and rigth
        float move = Input.GetAxisRaw("Horizontal");
        myRb.velocity = new Vector2(move * moveSpeed, myRb.velocity.y);
       


        if (move>0 &&!faceRight)
        {
            flip();
            Debug.Log("Faceing Right");
        }else if(move<0 && faceRight)
        {
            flip();
            Debug.Log("Not Facing Right");
        }

        //Firing projectiles

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }
    }

    // Flip Player sprite when moving left or rigth
    void flip()
    {
        faceRight = !faceRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    
}
