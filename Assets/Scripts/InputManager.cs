using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
   Player PlayerInput;

   bool submitPressed;


   private static InputManager instance;


   private void Awake()
   {
	  if (instance!=null)
	  {
         Debug.LogError("Found more than one inputmanager script in the scene");
	  }

      instance = this;


      PlayerInput = new Player();

      PlayerInput.PlayerContr.Enable();

      PlayerInput.PlayerContr.Submit.performed += Submit;

   }


   void Submit(InputAction.CallbackContext ctx)
   {
      print("submit");

	  if (ctx.performed)
	  {
         submitPressed = true;
	  }
	  else if (ctx.canceled)
	  {
         submitPressed = false;
	  }

   }


   public bool GetSubmitPressed()
   {
      bool result = submitPressed;
      submitPressed = false;
      return result;
   }

   public void RegisterSubmitPressed()
   {
      submitPressed = false;

   }


   public static InputManager GetInstance()
   {
      return instance;


   }

   private void OnEnable()
   {
      PlayerInput.Enable();
   }

   private void OnDisable()
   {
      PlayerInput.Disable();
   }
}
