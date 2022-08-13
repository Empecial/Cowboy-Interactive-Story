using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneyNPC : MonoBehaviour
{
   [SerializeField] Color defaultColor;
   [SerializeField] Color o3;
   [SerializeField] Color over100;
   [SerializeField] Color waymore;

   MeshRenderer meshrenderer;

   // Start is called before the first frame updat
   void Start()
   {
      meshrenderer = GetComponent<MeshRenderer>();


   }

   // Update is called once per frame
   void Update()
   {
      string moneyamount = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("money_count")).value;

      switch (moneyamount)
      {
		 case  "":
            meshrenderer.material.color = defaultColor;
            break;

         case "over 100" :
            meshrenderer.material.color = over100;
            break;

         case "3":
            meshrenderer.material.color = o3;
            break;

         case "big schlong":
            meshrenderer.material.color = waymore;
            break;


         default:
            print("shit is fucked");
            break;
      }

   }
}
