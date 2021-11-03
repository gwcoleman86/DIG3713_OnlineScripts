using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stealth : MonoBehaviour {

    private bool isHidden = false;
    public bool isDetected = false;
	// Use this for initialization
	void Start () {
        //If your player starts in cover, change this to true. Shouldn't be too big of an issue though.
        isHidden = false;
        isDetected = false;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Cover"))
        {
            isHidden = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // I couldn't think of a better tag name than GuardView. Feel free to change it if you come up with a better name
        if (collision.CompareTag("GuardView"))
        {
            if (!isHidden)
            {
                if (!isDetected)
                {
                    isDetected = true;
                    Detected();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Cover"))
        {
            isHidden = false;
        }
    }



    void Detected() //TODO
    {
        // Here is where you fill in the rest. What happens when an enemy sees you?
        // Do you take damage? Do you respawn? Does it trigger an event? This part is 
        // up to you.
    }
}
