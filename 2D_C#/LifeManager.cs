using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {
    /// <summary>
    /// Must setup Life counter UI.
    /// </summary>

    public int startingLives;
    private int currentLives;

    public Text LiveText;


	// Use this for initialization
	void Start () {
        LiveText = GetComponent<Text>();
        currentLives = startingLives;
	}
	
	// Update is called once per frame
	void Update () {
        LiveText.text = "X " + currentLives;
	}

    public void GiveLife()
    {
        currentLives++;
    }
    public void takeLife()
    {
        currentLives--;
    }
}
