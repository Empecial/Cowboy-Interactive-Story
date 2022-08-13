using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaloonRobbery : MonoBehaviour
{



    SheriffStrangerOutsideEncounter sheriffEncounterRef;

    
    public float BanditRunningSpeed;



    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject SaloonDialogueTrigger;

    public bool EnemyModeEnabled;

    public string DialogueVariable;

    public bool RobberLeft = false;
    public bool SheriffHatEncounterEnabled=false;


    public Transform SaloonDoorToExit;

    


    void Start()
    {
        sheriffEncounterRef.EnableSheriffScenario();

    }


    private void OnTriggerEnter(Collider other)
    {
        if (this.transform.position.x == SaloonDoorToExit.gameObject.transform.position.x)
        {
            RobberLeft = true;
            print("robber exited");
        }
    }

    void Update()
    {

        print(SheriffHatEncounterEnabled);

        Vector3 ThisBanditPos = transform.position;

        Vector3 saloonDoor = SaloonDoorToExit.position;

        string SaloonRobberyVariable = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState(DialogueVariable)).value;


        switch (SaloonRobberyVariable)
        {
            case "":

                break;

            case "force":

                SheriffHatEncounterEnabled = true;

                if (!DialogueManager.GetInstance().DialogueIsPlaying)
                { 
                    Instantiate(EnemyPrefab, this.transform.position,Quaternion.identity );
                gameObject.SetActive(false);

                }

                

                break;

            case "persuade":

                SheriffHatEncounterEnabled = true;

                transform.position = Vector3.MoveTowards(ThisBanditPos, saloonDoor, BanditRunningSpeed);


                if (this.transform.position.x == SaloonDoorToExit.gameObject.transform.position.x)
                {
                    gameObject.SetActive(false);
                    print("robber ignored");
                }
                break;


            case "ignore":

                transform.position = Vector3.MoveTowards(ThisBanditPos, saloonDoor, BanditRunningSpeed);
                SheriffHatEncounterEnabled = true;


                if (this.transform.position.x == SaloonDoorToExit.gameObject.transform.position.x)
                {
                    gameObject.SetActive(false);
                    print("robber ignored");
                }
                break;

            default:
                print("value cannot be read");
                break;
        }
    }
}
