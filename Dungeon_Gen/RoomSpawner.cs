using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {

    public int openingDirection;
    // 1 --> need bottom Door
    // 2 --> need top Door
    // 3 --> need left Door
    // 4 --> need right Door

    private RoomTemplates roomTemplates;
    private int rand;
    private bool spawned = false;

    public float waitTime = 4f;

     void Start()
    {
        Destroy(gameObject, waitTime);
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }






    void Spawn()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                //Spawn Bottom Door
                rand = Random.Range(0, roomTemplates.bottomRooms.Length);
                Instantiate(roomTemplates.bottomRooms[rand], transform.position, roomTemplates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //Spawn Top Door
                rand = Random.Range(0, roomTemplates.topRooms.Length);
                Instantiate(roomTemplates.topRooms[rand], transform.position, roomTemplates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Spawn left Door
                rand = Random.Range(0, roomTemplates.leftRooms.Length);
                Instantiate(roomTemplates.leftRooms[rand], transform.position, roomTemplates.leftRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //Spawn right Door
                rand = Random.Range(0, roomTemplates.rightRooms.Length);
                Instantiate(roomTemplates.rightRooms[rand], transform.position, roomTemplates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //&& other.GetComponent<RoomSpawner>().spawned == true
        if (other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                // Create a close room
                Instantiate(roomTemplates.closeRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
