using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacking : MonoBehaviour
{
    public GameObject Bandit1;
    public GameObject Bandit2;
    public GameObject Sheriff;

    public SphereCollider right;


    public float behit = 0.1f;
    public float health = 3;

    public float healthB1 = 3;
    public float healthB2 = 5;
    public float healthS = 7;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || right.tag == "Enemy")
        {
            Debug.Log("lort");
            behit = 1f;
            health -= 1;
            //enem1.AddForce(player.transform.position - enemy1.transform.position);
        }

        

        if (other.tag == "Bandit1" || right.tag == "Bandit1")
        {
            behit = 1f;
            healthB1 -= 1;

            if(healthB1 == 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.tag == "Bandit2" || right.tag == "Bandit2")
        {
            healthB2 -= 1;
            if (healthB1 == 0)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.tag == "Sheriff" || right.tag == "Sheriff")
        {
            healthS -= 1;
            if (healthB1 == 0)
            {
                Destroy(other.gameObject);
            }
        }


        if (healthB1 <= 0)
        {
            Bandit1.SetActive(false);
        }
        if (healthB2 <= 0)
        {
            Bandit2.SetActive(false);
        }

        if (healthS <= 0)
        {
            Sheriff.SetActive(false);
        }

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        behit -= Time.deltaTime;



    }
}
