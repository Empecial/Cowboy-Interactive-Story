using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopkeeperMilkQuest : MonoBehaviour
{
    EnemyAttack enemyAttackRef;

    public GameObject MilkBucket;

    void Start()
    {
        enemyAttackRef = GetComponent<EnemyAttack>();
    }

    void Update()
    {
        string ShopKeeperMilkFetchQuest = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("ShopKeeperMilk")).value;


        switch (ShopKeeperMilkFetchQuest)
        {
            case "":
                break;

            case "taken":

                MilkBucket.SetActive(false);

                break;

            case "nothing3":

                break;

            case "nothing":

                break;

            case "nothing2":

                break;

            default:
                print("value cannot be read");
                break;
        }
    }
}
