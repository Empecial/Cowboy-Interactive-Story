using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
	public Animator playeranim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, olwb_speed, rn_speed, ro_speed; // walking, walking back, old walking, old walking back, running, rotating
	public bool walking, NPCarea;
	public Transform playerTrans;


	private void FixedUpdate()
	{

		//z-axis movement
		if (Input.GetKey(KeyCode.W))
		{
			playerRigid.velocity = transform.forward * w_speed;
		}

		if (Input.GetKey(KeyCode.S))
		{
			playerRigid.velocity = -transform.forward * wb_speed;
		}
	}

	void Update()
	{


		//checks if player is in dialogue. if true, stops all player movement but
		//still allows player to choose dialogue options
		if (NPCarea)
		{
			if (DialogueManager.GetInstance().DialogueIsPlaying)
			{
				print("dialogue running");
				w_speed = 0;
				wb_speed = 0;
				return;
			}

			else if (!DialogueManager.GetInstance().DialogueIsPlaying)
			{
				print("speeds restored");
				w_speed = olw_speed;
				wb_speed = olwb_speed;
			}

		}



		//directional keyinputs
		if (Input.GetKeyDown(KeyCode.W))
		{
			playeranim.SetTrigger("walk");
			playeranim.ResetTrigger("idle");
			walking = true;

		}

		if ((Input.GetKeyUp(KeyCode.W)))
		{
			playeranim.SetTrigger("idle");
			playeranim.ResetTrigger("walk");
			walking = false;
		}

		if ((Input.GetKeyDown(KeyCode.S)))
		{
			playeranim.SetTrigger("walkbackwards");
			playeranim.ResetTrigger("idle");


		}

		if ((Input.GetKeyUp(KeyCode.S)))
		{
			playeranim.SetTrigger("idle");
			playeranim.ResetTrigger("walkbackwards");
		}

		if ((Input.GetKey(KeyCode.A)))
		{
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}

		if ((Input.GetKey(KeyCode.D)))
		{
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}

		if (walking)
		{
			if ((Input.GetKeyDown(KeyCode.LeftShift)))
			{
				print("walk1" + w_speed);
				w_speed += rn_speed;
				print("walk2" + w_speed);


				playeranim.SetTrigger("run");
				playeranim.ResetTrigger("walk");

			}

			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				w_speed = olw_speed;
				playeranim.SetTrigger("walk");
				playeranim.ResetTrigger("run");

			}
		}

	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "trigger")
		{
			NPCarea = true;
			print("collided with NPC");
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "trigger")
		{
			NPCarea = false;
		}
	}


}
