using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour {
/// <summary>
/// TO MAKE PLATFORMS MOVE YOU WILL NEED TO SET UP POINTS. 
/// </summary>

    public float moveSpeed;
    private float waitTime;
    public float startwaitTime;

    public Transform[] movePoints;
    private int randomPoint;

	// Use this for initialization
	void Start () {
        waitTime = startwaitTime;
        randomPoint = Random.Range(0, movePoints.Length);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, movePoints[randomPoint].position, 
            moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePoints[randomPoint].position) < 0.2f)
        {
            if(waitTime <= 0)
            {
                randomPoint = Random.Range(0, movePoints.Length);
                waitTime = startwaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
	}
}
