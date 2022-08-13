using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{


   [SerializeField] private GameObject VisualCue;
   [SerializeField] GameObject HealthbarGB;
   [SerializeField] private bool inRange;

   [SerializeField] TextAsset inkJSON;
   private void Awake()
   {
	  HealthbarGB = GameObject.Find("Health");


	  VisualCue.SetActive(false);
	  inRange = false;
   }

   private void OnTriggerEnter(Collider other)
   {
	  if (other.gameObject.tag == "Player")
	  {
		 print("player is in range");
		 inRange = true;
	  }
   }

   
   
   private void OnCollisionEnter(Collision collision)
   {
	  if (collision.gameObject.name == "Player")
	  {
		 print("player is in range");
		 inRange = true;
	  }
   }

   private void OnTriggerExit(Collider other)
   {
	  if (other.gameObject.tag== "Player")
	  {
		 print("player is not in range");

		 inRange = false;
	  }
   }


   private void Update()
   {
	  if (inRange && !DialogueManager.GetInstance().DialogueIsPlaying)
	  {
		 VisualCue.SetActive(true);
		 if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
		 {

			HealthbarGB.SetActive(false);

			DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
		 }
	  }
	  else
	  {
		 VisualCue.SetActive(false);
	  }
   }


}
