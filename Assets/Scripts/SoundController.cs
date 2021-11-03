using UnityEngine;
using System.Collections;

//Add this Script Directly to The Death Zone
public class SoundController : MonoBehaviour
{
    public AudioClip Chirp;    // Add your Audi Clip Here;
                               // This Will Configure the  AudioSource Component; 
                               // MAke Sure You added AudioSouce to death Zone;
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
        GetComponent<AudioSource>().clip = Chirp;
    }

    void OnCollisionEnter2D(Collision2D collision)  //Plays Sound Whenever collision detected
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("is playing");
            GetComponent<AudioSource>().Play();
            transform.position = Vector2.zero;
            Invoke("SelfDestruct", 2);
        }


        // Make sure that deathzone has a collider, box, or mesh.. ect..,
        // Make sure to turn "off" collider trigger for your deathzone Area;
        // Make sure That anything that collides into deathzone, is rigidbody;
    }

    public void SelfDestruct()
    {
        Destroy(gameObject);
    }




}
