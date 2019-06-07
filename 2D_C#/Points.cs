using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour {
    /// <summary>
    /// Must be place on object in order get points
    /// </summary>
    

    public int gainPoints;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Score.score += gainPoints;
        }

        Destroy(gameObject);

    }
}
