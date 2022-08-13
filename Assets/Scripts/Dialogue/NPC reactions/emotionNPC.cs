using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class emotionNPC : MonoBehaviour
{
   [SerializeField] Color defaultColor = Color.white;
   [SerializeField] Color red = Color.red;
   [SerializeField] Color blue = Color.blue;
   [SerializeField] Color green = Color.green;

   MeshRenderer meshrenderer;

   //public string[] emotions;

   //public GameObject gbvarRef;

   DialogueVariables dialoguevarRef;

   // Start is called before the first frame update
   void Start()
    {
      //dialoguevarRef = gbvarRef.GetComponent<DialogueVariables>();


      //emotions = dialoguevarRef.DialogueChoices;

      meshrenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      string Emotionstate = ((Ink.Runtime.StringValue)DialogueManager.GetInstance().GetVariableState("emotion_state")).value;


	  switch (Emotionstate)
	  {
         case "": meshrenderer.material.color = defaultColor;
            break;

         case "happy": meshrenderer.material.color = blue;
            break;

         case "sad": meshrenderer.material.color = red;
            break;

         case "bighappy": meshrenderer.material.color = Color.black;
            break;


		 default: print("given file doesnt work");
			break;
	  }

   }
}
