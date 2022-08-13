using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Bull;
    public Rigidbody rb;
    public float bulspeed;
    public Vector3 PPos;
    bool temp = true;
    Vector3 tempo;
    PlayerControl CC;
    public float Dodgy;
    void Start()
    {

        if(temp == true)
        {
            Player = GameObject.FindWithTag("Player");
            Bull = gameObject;

            
            PPos = Player.transform.localPosition;
            Bull.transform.LookAt(PPos, Vector3.down);
            Bull.transform.Rotate(90, 0, 0);
            //Debug.Log(PPos.x + " " + PPos.y + " " + PPos.z);
            temp = false;
            tempo = (PPos - transform.position).normalized;

        }
    }
    void Update()
    {
        CC = Player.GetComponent<PlayerControl>();
        Dodgy = CC.dodgeTimer;
        if (temp == false)
        {
                transform.position += tempo * bulspeed * Time.deltaTime; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WALL")
        {
            Destroy(Bull);
        }

        if(other.tag == "Player")
        {
            if(Dodgy > 0.3)
            {
                Destroy(Bull);

            }
            else
            {
                
            }
            
        }

    }
}
