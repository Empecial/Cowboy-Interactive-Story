using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sizeNPC : MonoBehaviour
{
   [SerializeField] Color defaultColor;
   [SerializeField] Color case4;
   [SerializeField] Color case12;
   [SerializeField] Color schlong;

   MeshRenderer meshrenderer;

   // Start is called before the first frame update
   void Start()
   {
      meshrenderer = GetComponent<MeshRenderer>();


   }

   // Update is called once per frame
   void Update()
   {
      string assSize = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("ass_size")).value;


      switch (assSize)
      {
         case "":
            meshrenderer.material.color = defaultColor;
            break;

         case "12":
            meshrenderer.material.color = case12;
            break;

         case "4":
            meshrenderer.material.color = case4;
            break;

         case "big schlong":
            meshrenderer.material.color = schlong;
            break;


         default:
            print("shit is fucked");
            break;
      }

   }
}
