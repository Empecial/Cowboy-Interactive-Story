using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPDOOR : MonoBehaviour
{
    [Header("Saloon Doors")]
    public Transform SaloonExteriorEnter;
    public Transform SaloonExteriorExit;
    public Transform SaloonEnterInterior;
    public Transform SaloonExitInterior;

    [Header("Shop Doors")]
    public Transform ShopExteriorEnter;
    public Transform ShopExteriorExit;
    public Transform ShopEnterInterior;
    public Transform ShopExitInterior;

    [Header("Respawn")]
    public Transform DefaultRespawnSpot;
    public Transform OutOfBoundsRespawn;

    public Transform PlayerPosition;

    public GameObject TriggerSaloonBanditGB;
    [SerializeField] GameObject SaloonDialogueTrigger;


    public bool SaloonRobberyOccur;

    public GameObject Sun;

    private void Start()
    {


        SaloonRobberyOccur = false;

        print(gameObject.name);
    }

    void DeactivateSaloonDialogue()
    {
        SaloonDialogueTrigger.SetActive(false);

    }


    private void OnTriggerEnter(Collider other)
    {

        //saloon teleportation
        if (other.name == TriggerSaloonBanditGB.name)
        {
            SaloonDialogueTrigger.SetActive(true);
            SaloonRobberyOccur = true;
            TriggerSaloonBanditGB.SetActive(false);
            Invoke("DeactivateSaloonDialogue", 2);
        }

        
        if (other.name == SaloonExteriorEnter.name)
        {
            PlayerPosition.position = SaloonEnterInterior.transform.position;
            Sun.SetActive(false);
            
        }

        if (other.name == SaloonExitInterior.name)
        {
            Sun.SetActive(true);
            PlayerPosition.position = SaloonExteriorExit.position;
            print("exit saloon");

        }


        //shop teleportation
        if (other.name==ShopExteriorEnter.name)
        {
            PlayerPosition.position = ShopEnterInterior.position;
            Sun.SetActive(false);

        }

        if (other.name==ShopExitInterior.name)
        {
            PlayerPosition.position = ShopExteriorExit.position;
            Sun.SetActive(true);
        }


        //default respawn - has player fallen off the map?

        if (other.name== OutOfBoundsRespawn.name)
        {
            PlayerPosition.position = DefaultRespawnSpot.position;
        }

    }



}
