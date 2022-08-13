using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundmove : MonoBehaviour
{
    public AudioSource Sound;

    bool nosound = false;
    public Rigidbody rb;
    bool ismov;
    int count;
    public PlayerControl pc;
    // Update is called once per frame
    //lol
    void Update()
    {

            if (rb.velocity.z != 0)
            {
                if (!Sound.isPlaying)
                {
                    Sound.Play();
                }
            }
            else if (rb.velocity.x != 0)
            {
                if (!Sound.isPlaying)
                {
                    Sound.Play();
                }

            }
            else
            {
                Sound.Stop();
            }
        
       

        


        /*
        if (rb.velocity.x != 0)
        {
            if(!Sound.isPlaying)
            {
                Sound.Play();
            } 
        }
        else
        {
            Sound.Stop();
        }
        */


        /*
        nosound = false;
        if (Input.GetKey(KeyCode.W))
        {
            Sound.Play();
            nosound = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Sound.Play();
            nosound = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Sound.Play();
            nosound = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Sound.Play();
            nosound = true;
        }
        if(nosound == false)
        {
            Sound.Stop();
        }
        

        
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            Sound.Play()
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            Sound.Play()
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            Sound.Play()
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            Sound.Play()
        }
        */
    }
}
