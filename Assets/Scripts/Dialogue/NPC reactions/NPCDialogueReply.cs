using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueReply : MonoBehaviour
{
    [SerializeField] Color defaultColor;
    [SerializeField] Color insult;
    [SerializeField] Color romance;
    [SerializeField] Color confess;

    MeshRenderer meshrenderer;

    EnemyAttack enemyAttackRef;
    [SerializeField] LineRenderer lr;



    public string[] GameobjectsToDisable;

    [SerializeField] GameObject EnemyPrefab;
    [SerializeField] GameObject SheriffGB;

    public bool EnemyModeEnabled;

    public string DialogueVariable;


    void Start()
    {
        meshrenderer = GetComponent<MeshRenderer>();

        enemyAttackRef = GetComponent<EnemyAttack>();

        lr = EnemyPrefab.GetComponent<LineRenderer>();


    }


    void EnemyModeActivated()
    {

        


        lr.enabled = true;

        enemyAttackRef.enabled = true;

        print("enemy mode enabled on: " + gameObject.name);
    }

    void Update()
    {

        if (EnemyModeEnabled)
        {
            EnemyModeActivated();

        }


        string SheriffBrothersHatEncounterNPC = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState(DialogueVariable)).value;


        switch (SheriffBrothersHatEncounterNPC)
        {
            case "":
                meshrenderer.material.color = defaultColor;
                break;

            case "insult":
                meshrenderer.material.color = insult;

                /*EnemyPrefab.SetActive(true);
                meshrenderer.enabled = false;*/



                break;

            case "romance":
                meshrenderer.material.color = romance;
                break;

            case "confess":
                meshrenderer.material.color = confess;
                break;


            default:
                print("value cannot be read");
                break;
        }
    }
}
