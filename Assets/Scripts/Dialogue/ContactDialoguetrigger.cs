using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ContactDialoguetrigger : MonoBehaviour
{

	bool TriggerDialogue;

	GameObject HealthbarGB;

	public bool DisableTriggerAfterDialogue;

	[SerializeField] TextAsset inkJSON;
	private void Awake()
	{
		HealthbarGB = GameObject.Find("Health");
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			print("triggerenter");
			TriggerDialogue = true;
		}
	}



	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			print("player is not in range");

			
		}
	}

	//aaa
	private void Update()
	{
		if (!DialogueManager.GetInstance().DialogueIsPlaying)
		{
			if (TriggerDialogue)
			{
				HealthbarGB.SetActive(false);

				DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
				TriggerDialogue = false;

                if (DisableTriggerAfterDialogue)
                {
					Destroy(this.gameObject);
                }
			}
		}
		
	}


}
