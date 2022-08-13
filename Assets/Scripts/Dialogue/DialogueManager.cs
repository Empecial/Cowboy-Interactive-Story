using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.UI;
using UnityEngine.EventSystems;
 

public class DialogueManager : MonoBehaviour
{
   private static DialogueManager instance;

   [Header("Dialogue UI")]
   [SerializeField] private GameObject dialoguePanel;
   [SerializeField] private GameObject continueIcon;
   [SerializeField] private TextMeshProUGUI dialoguetext;
   [SerializeField] private TextMeshProUGUI displayNameText;
   [SerializeField] private Animator portraitAnimator;
   private Animator layoutAnimator;

   [Header("Choices UI")]
   [SerializeField] private GameObject[] choices;
   private TextMeshProUGUI[] ChoicesText;


   [Header("Load Globals JSON")]
   [SerializeField] private TextAsset loadGlobalsJSON;

   //tags to look for in dialogue
   private const string speaker_tag = "speaker";
   private const string portrait_tag = "portrait";
   private const string layout_tag = "layout";


   private DialogueVariables dialogueVariablesRef;

   [Header("Story elements")]
   private Story currentStory;

   [SerializeField] float typingSpeed;
   private Coroutine displayLineCoroutine;

   [SerializeField] GameObject HealthbarGB;
   

   //outside scripts can read this value, but cant modify it
   //which is why the set value is private
   public bool DialogueIsPlaying { get; private set; }

   private bool canContinueToNextLine = false;

   private void Awake()
   {
	  //if more than one instance of script exists, show warning
	  if (instance!=null)
	  {
		 Debug.LogWarning("more than one dialogue manager in the scene");
	  }

	  instance = this;

	  dialogueVariablesRef = new DialogueVariables(loadGlobalsJSON);
   }

   public static DialogueManager GetInstance()
   {
	  return instance;
   }

   private void Start()
   {
	  DialogueIsPlaying = false;
	  dialoguePanel.SetActive(false);

	  //gets layout animator from dialoguepanel
	  layoutAnimator = dialoguePanel.GetComponent<Animator>();


	  //get all choices text
	  ChoicesText = new TextMeshProUGUI[choices.Length];

	  int index = 0;

	  //takes all the text from the choice gameobjects and puts into text array
	  foreach (GameObject choice in choices)
	  {
		 ChoicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
		 index++;
	  }
   }

   public void EnterDialogueMode(TextAsset inkJSON)
   {
	  currentStory = new Story(inkJSON.text);
	  DialogueIsPlaying = true;
	  dialoguePanel.SetActive(true);

	  dialogueVariablesRef.StartListening(currentStory);



	  //resets portrait, speaker frame and layout
	  displayNameText.text = "???";
	  portraitAnimator.Play("default");
	  layoutAnimator.Play("right");

	  ContinueStory();
   }

   private IEnumerator ExitDialogueMode()
   {
	  yield return new WaitForSeconds(1f);

	  dialogueVariablesRef.StopListening(currentStory);

	  //stops the dialogue and resets the text contents of dialoguetext
	  DialogueIsPlaying = false;
	  dialoguePanel.SetActive(false);
	  dialoguetext.text = "";

	  HealthbarGB.SetActive(true);

   }

   void ContinueStory()
   {
	  //checks if story can continue (not in the middle of a line) and then shows
	  //the next line of dialogue. If it cant continue, then it will exit dialoguemode
		 		
	  if (currentStory.canContinue)
	  {
		 print("story continue");

		 //checks if specified coroutine is already existing and playing or not. 
		 //cant check for coroutine = null since it will return an error
		 if (displayLineCoroutine != null)
		 {
			StopCoroutine(displayLineCoroutine);
		 }

		 //will set the dialogue coroutine to be the currently running coroutine 
		 displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));          

		 //handling tags
		 HandleTags(currentStory.currentTags);
	  }
	  else
	  {
		  print("story no continue");
		  StartCoroutine(ExitDialogueMode());
	  }
   }


   private IEnumerator DisplayLine(string line)
   {
	  //empty the dialogue text ingame for each line
	  dialoguetext.text = line;
	  dialoguetext.maxVisibleCharacters = 0;

	  //hide continue icon while text is typing
	  continueIcon.SetActive(false);

	  //hides all possible choices
	  HideChoices();


	  canContinueToNextLine = false;

	  bool isAddingRichTextTag = false;
	 
	  foreach (char letter in line.ToCharArray())
	  {
		 if (InputManager.GetInstance().GetSubmitPressed())
		 {
			dialoguetext.maxVisibleCharacters = line.Length;
			break;
		 }

		 //checks if dialogue has rich text tags for color and other property changes
		 if (letter == '<' || isAddingRichTextTag)
		 {
			isAddingRichTextTag = true;
			print("richtext tag true");

			//checks if the rich text tag section is done, in which case the bool is false
			if (letter == '>')
			{
			   isAddingRichTextTag = false;
			   print("richtext tag false");
			}
		 }
		 else
		 { 
		 
		 dialoguetext.maxVisibleCharacters++;
		 yield return new WaitForSeconds(typingSpeed);

		 }

		
	  }

	  //continueicon showing up after everything has been displayed
	  continueIcon.SetActive(true);

	  //will display all possible choice after all dialogue has been written
	  DisplayChoices();

	  canContinueToNextLine = true;

   }

   void HideChoices()
   {
	  //loops through all choice buttons and hides them since dialogue hasnt been written
	  foreach (GameObject choiceButton in choices)
	  {
		 choiceButton.SetActive(false);
	  }
   }

   void HandleTags(List<string> currentTags)
   {
	  foreach (string tag in currentTags)
	  {
		 string[] splitTag = tag.Split(':');
		 if (splitTag.Length !=2)
		 {
			Debug.LogError("Tag could not be appropriately parsed: " + tag);
		 }

		 string tagKey = splitTag[0].Trim();
		 string tagValue = splitTag[1].Trim();

		 switch (tagKey)
		 {
			case speaker_tag:
			   print("Speaker= " + tagValue);
			   displayNameText.text = tagValue;
			   break;

			case layout_tag:
			   print("Layout= " + tagValue);
			   layoutAnimator.Play(tagValue);
			   break;

			case portrait_tag:
			   portraitAnimator.Play(tagValue);
			   print("Portrait= " + tagValue);
			   break;


			default:
			   Debug.LogWarning("Tag is in but not currently being handled: " + tag);
			   break;
		 }

	  }

   }


   private void DisplayChoices()
   {
	  List<Choice> currentChoices = currentStory.currentChoices;

	  if (currentChoices.Count > choices.Length)
	  {
		 Debug.LogError("Too many choices compared to how much the UI has space for. Number of choices: " + currentChoices.Count);
	  }

	  int index = 0;

	  //shows the amount of choices and text for the amount of choices in this line of dialogue
	  foreach (Choice choice in currentChoices)
	  {
		 choices[index].gameObject.SetActive(true);
		 ChoicesText[index].text = choice.text;
		 index++;
	  }

	  //goes through the remaining choices if not enough gameobjects and more are left, and disables them
	  for (int i = index; i < choices.Length; i++)
	  {
		 choices[i].gameObject.SetActive(false);
	  }

	  StartCoroutine(SelectedFirstChoice());
   }

   private IEnumerator SelectedFirstChoice()
   {
	  //event system needs the selected object cleared at least a frame 
	  //before a gameobject is selected. this is for choices

	  EventSystem.current.SetSelectedGameObject(null);
		 yield return new WaitForSeconds(0.1f);
	  EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
   }


   public void MakeChoice(int choiceIndex)
   {
		 
		 currentStory.ChooseChoiceIndex(choiceIndex);

	  InputManager.GetInstance().RegisterSubmitPressed();
		 ContinueStory();

		 
   }

   public Ink.Runtime.Object GetVariableState(string variableName)
   {
	  Ink.Runtime.Object variableValue = null;
	  dialogueVariablesRef.variables.TryGetValue(variableName, out variableValue);

	  if (variableValue==null)
	  {
		 print("Ink Variable was found to be null: " + variableName);
	  }
	  return variableValue;
   }




   private void Update()
   {
	  if (!DialogueIsPlaying)
	  {
		 return;
	  }

	  //currentchoices.count is bugfixing
	  if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && InputManager.GetInstance().GetSubmitPressed())
	  {
		 ContinueStory();
	  }
   }

}
