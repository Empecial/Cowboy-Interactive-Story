using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //public GameObject Enemy;
    public GameObject Player;
    public GameObject Laser;
    public GameObject Bullet;
    public GameObject BulletV;
    public GameObject BulletH;

    public SphereCollider sp;
    public Attacking atc;
    public float Timer;
    public float TimerFix;
    public float speeder;
    public bool StartTime = false;
    public bool Shotgun = false;
    public float beenhit = 1f;
    private LineRenderer lr;
    [SerializeField]
    private Transform startpoint;


    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.enabled = false;
    }
    void Update()
    {
        if (beenhit < 0)
        {
            if (lr.enabled == true)
            {
                this.transform.LookAt(Player.transform, Vector3.up);


                this.transform.Rotate(0, 90, 0);


                lr.SetPosition(0, startpoint.position);
                RaycastHit hit;
                if (Physics.Raycast(transform.position, -transform.right, out hit))
                {
                    if (hit.collider)
                    {
                        lr.SetPosition(1, hit.point);
                    }
                    if (hit.transform.tag == "Player")
                    {

                    }
                }
                else
                {
                    lr.SetPosition(-1, -transform.right * 500);
                }
            }
        }




    }

    private void FixedUpdate()
    {
        beenhit = atc.behit;
        if (beenhit < 0)
        {
            if (StartTime == true)
            {
                if (Timer > 0)
                {
                    Timer -= Time.deltaTime;
                }
            }
            if (Timer <= 0)
            {
                TimerFix -= Time.deltaTime;
                if (TimerFix <= 0)
                {
                    Instantiate(Bullet, this.transform.position, Quaternion.identity);
                    if (Shotgun == true)
                    {
                        Instantiate(BulletH, this.transform.position, Quaternion.identity);
                        Instantiate(BulletV, this.transform.position, Quaternion.identity);
                    }

                    Timer = speeder;
                    TimerFix = speeder;
                }


            }
        }




    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            lr.enabled = true;
            StartTime = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            lr.enabled = false;
            StartTime = false;
            Timer = 0.1f;
            TimerFix = 0.1f;
        }

    }
}
