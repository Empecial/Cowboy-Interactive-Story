using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet3 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    public GameObject Bullh;
    public Rigidbody rb;
    public float bulspeed;
    public Vector3 PPos;
    bool temp = true;
    Vector3 tempo;
    PlayerControl CC;
    public float Dodgy;
    void Start()
    {

        if (temp == true)
        {
            Player = GameObject.FindWithTag("Player");
            Bullh = gameObject;


            PPos = Player.transform.localPosition;
            Bullh.transform.LookAt(PPos, Vector3.down);
            Bullh.transform.Rotate(90, 0, 0);
            //Debug.Log(PPos.x + " " + PPos.y + " " + PPos.z);
            temp = false;
            tempo = (PPos - transform.position).normalized;

        }
    }
    bool once = true;
    void Update()
    {
        CC = Player.GetComponent<PlayerControl>();
        Dodgy = CC.dodgeTimer;


        if (once == true)
        {
            tempo += new Vector3(0 , 0, 1f).normalized;
            once = false;
        }

        if (temp == false)
        {

            Bullh.transform.position += tempo * bulspeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "WALL")
        {
            //Destroy(Bullv);
        }

        if (other.tag == "Player")
        {
            if (Dodgy > 0.3)
            {
                //Destroy(Bullv);
            }
            else
            {

            }

        }

    }
}
