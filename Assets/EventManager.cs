using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

    TPDOOR tpdoorRef;

    public GameObject playerGB;
    public GameObject RobberGB;

    public bool stop=false;

    // Start is called before the first frame update
    void Start()
    {
        tpdoorRef = playerGB.GetComponent<TPDOOR>();

       //RobberGB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (tpdoorRef.SaloonRobberyOccur)
        {
            SaloonRobbery();


        }
        else if (!tpdoorRef.SaloonRobberyOccur)
        {
            RobberGB.SetActive(false);
        }




    }



    void SaloonRobbery()
    {
        if (!stop)
        {
            RobberGB.SetActive(true);
            stop = true;

        }
        
    }

}
