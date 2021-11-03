using System.Diagnostics;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Sign : MonoBehaviour
{
    private Text message;
    private bool notHit;
    
    void Start()
    {
      
        message = GameObject.Find("Message").GetComponent<Text>();
        message.color = Color.white;
        message.text = "";
        notHit=true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && notHit)
        {
            message.text = "Warning: Deadly Fall";

        }
        
    }
    
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            message.text = "";
        }
    }
}
