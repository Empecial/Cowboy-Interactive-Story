using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheriffStrangerOutsideEncounter : MonoBehaviour
{
    


    EnemyAttack enemyAttackRef;
    public SaloonRobbery saloonRobberyRef;

    public float RunningSpeed;

    public GameObject[] barrels;
    public GameObject SheriffHatDialogueTrigger;

   [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject sheriffEnemyPrefab;
    [SerializeField] GameObject SheriffGB;
    [SerializeField] GameObject Stranger;
    public GameObject TargetObjectSheriffStranger;

    public bool SheriffStrangerScenario;


    public void EnableSheriffScenario()
    {
        SheriffGB.SetActive(true);

        Stranger.SetActive(true);
        this.gameObject.GetComponent<BoxCollider>().enabled=true;

        
    }

   void Start()
   {
        SheriffGB.SetActive(false);

        Stranger.SetActive(false);
        this.gameObject.GetComponent<BoxCollider>().enabled =false;

        foreach (GameObject barrel in barrels)
        {
            barrel.SetActive(false);
        }


    }

   void Update()
   {

        if (saloonRobberyRef.SheriffHatEncounterEnabled)
        {
            EnableSheriffScenario();
        }

        //destination for sheriff and stranger to go offscreen
        Vector3 SheriffPos = SheriffGB.transform.position;

        Vector3 StrangerPos = Stranger.transform.position;

        Vector3 TargetLocation = TargetObjectSheriffStranger.transform.position;



        string SheriffBrothersHatEncounterNPC = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("SheriffBrothersHatEncounter")).value;


      switch (SheriffBrothersHatEncounterNPC)
      {
         case "":
            break;

         case "insult":

                if (!DialogueManager.GetInstance().DialogueIsPlaying)
                {
                    Instantiate(sheriffEnemyPrefab, SheriffGB.transform.position, Quaternion.identity);
                    Instantiate(EnemyPrefab, Stranger.transform.position, Quaternion.identity);
                    gameObject.SetActive(false);
                    SheriffGB.SetActive(false);
                    Stranger.SetActive(false);


                }

                break;

         case "romance":

                SheriffGB.transform.position = Vector3.MoveTowards(SheriffGB.transform.position, TargetLocation, RunningSpeed);


                if (this.transform.position.x == TargetObjectSheriffStranger.transform.position.x)
                {
                    SheriffGB.gameObject.SetActive(false);
                    Stranger.gameObject.SetActive(false);
                    gameObject.SetActive(false);
                    TargetObjectSheriffStranger.SetActive(false);
                    print("robber ignored");
                }

                break;

         case "confess":


            break;

            case "barrel":

                foreach (GameObject barrel in barrels)
                {
                    barrel.SetActive(true);
                }
                
                if (!DialogueManager.GetInstance().DialogueIsPlaying)
                    {
                        Instantiate(sheriffEnemyPrefab, SheriffGB.transform.position, Quaternion.identity);
                        Instantiate(EnemyPrefab, Stranger.transform.position, Quaternion.identity);
                        gameObject.SetActive(false);
                        SheriffGB.SetActive(false);
                        Stranger.SetActive(false);
                    }

                break;

         default:
            print("value cannot be read");
            break;
      }
   }
}
