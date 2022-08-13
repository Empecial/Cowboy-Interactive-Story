using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
public class DialogueVariables
{

   public static DialogueVariables instance;

   public string[] DialogueChoices;


   public Dictionary<string, Ink.Runtime.Object> variables { get; private set; }


   private void Awake()
   {
	  //if more than one instance of script exists, show warning
	 /* if (instance != null)
	  {
		 Debug.LogWarning("more than one dialoguevariables script in the scene");
	  }

	  instance = this;
   }

   public static DialogueVariables GetInstance()
   {
	  return instance;*/
   }

   public DialogueVariables(TextAsset loadGlobalsJSON)
   {
	  //creates the story from the text asset
	  Story globalVariablesStory = new Story(loadGlobalsJSON.text);

	  //initialises the dictionary
	  variables = new Dictionary<string, Ink.Runtime.Object>();
	  foreach (string name in globalVariablesStory.variablesState)
	  {
		 Ink.Runtime.Object value = globalVariablesStory.variablesState.GetVariableWithName(name);
		 variables.Add(name, value);

		 Debug.Log("Initialized global dialogue variable: " + name + "=" + value);


	  }

   }
   public void StartListening(Story story)
   {
	  //important that VariablesToStory is assigned before assigning the listener
	  VariablesToStory(story);


	  //makes variablechanged a listener for when a variable in dialogue changes
	  story.variablesState.variableChangedEvent += VariableChanged;


   }


   public void StopListening(Story story)
   {
	  story.variablesState.variableChangedEvent -= VariableChanged;


   }



   //Ink.Runtime.Object is the value of the object to be used in dialogue
   private void VariableChanged(string name, Ink.Runtime.Object value)
   {
	  Debug.Log("variable changed:" + name + "=" + value );

	  //only maintains variables that were initializd from the globals ink file
	  //if the variable doesnt exist in the globals file, this part wont touch it

	  if (variables.ContainsKey(name))
	  {
		 variables.Remove(name);
		 variables.Add(name, value);


	  }
   }


   private void VariablesToStory(Story story)
   {
	  foreach (KeyValuePair<string, Ink.Runtime.Object> variable in variables)
	  {
		 story.variablesState.SetGlobal(variable.Key, variable.Value);
	  }


   }



}
