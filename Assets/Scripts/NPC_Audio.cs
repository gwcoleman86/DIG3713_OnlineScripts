﻿using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC_Audio : MonoBehaviour
{
    private Text message;
    private bool notHit;
    private AudioSource audioSource;
    public AudioClip textSound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = textSound;
        //Create Text component of a canvas object through unity named "Message"
        message = GameObject.Find("Message").GetComponent<Text>();
        //message.color = Color.white;
        message.text = "";
        notHit=true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && notHit)
        {
            StartCoroutine(displayText(other));

        }
        //Message to display if main dialogue is done
        else if(other.gameObject.tag == "Player" && !notHit)
        {
            message.text = "You must now move forward";
        }
    }
    IEnumerator displayText(Collider2D other)
    {
        message.text = "I am testing this system";
        other.gameObject.GetComponent<Player_Move>().playerSpeed = 0;
        //will continue after mouse button is clicked
        //copy this block for every new line of dialogue
        while (!Input.GetMouseButtonDown(0)) {
        yield return null;
        }
        audioSource.Play();

        message.text = "Your journey begins here";
        //



        //let player move again
        other.gameObject.GetComponent<Player_Move>().playerSpeed = 10;
        notHit=false;
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.text = "";
        }
        audioSource.Play();
    }
}
