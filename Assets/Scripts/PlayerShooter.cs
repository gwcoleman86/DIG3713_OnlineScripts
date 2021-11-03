using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {


    [SerializeField] private GameObject projectile;
    private bool facingRight = true;
    [SerializeField] private int MaxActiveShots;
    private Rigidbody2D rbdPlayer;
    
    // Use this for initialization
    void Start()
    {
        rbdPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (facingRight)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                transform.RotateAround(rbdPlayer.transform.position, Vector3.up, 180f);
                facingRight = false;
            }
        }else if (Input.GetAxis("Horizontal") > 0)
        {
            transform.RotateAround(rbdPlayer.transform.position, Vector3.up, 180f);
            facingRight = true;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (GameObject.FindGameObjectsWithTag("Attack").Length < MaxActiveShots)
            {
                GameObject shot = Instantiate(projectile);
                shot.transform.position = this.transform.position;
                shot.SetActive(true);
                float playerSpeed = rbdPlayer.velocity.x;
                shot.GetComponent<Projectile>().Launch(playerSpeed, facingRight);
            }
        }

    }
}
