using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.EventSystems;
public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    private static DialogueManager instance;
    private bool firstMessageRead;
    private DialogueVariables dialogueVariables;
    private void Awake(){
        if(instance!=null){
            Debug.LogWarning("Found multiple dialogue managers");
        }
        instance = this;
        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }
    public static DialogueManager GetInstance(){
        return instance;
    }
    private void Start(){
        dialogueIsPlaying=false;
        firstMessageRead = false;
        dialoguePanel.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach (GameObject choice in choices) {
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }
    }
    private void Update(){
        if(!dialogueIsPlaying){
            return;
        }
        if(Input.GetKeyDown("e")&&firstMessageRead&& currentStory.currentChoices.Count == 0) {
            ContinueStory();
        }
        firstMessageRead = true;
    }
    public void EnterDialogueMode(TextAsset inkJSON){
        Debug.Log("Entered Dialogue");
        currentStory =new Story(inkJSON.text);
       
        dialoguePanel.SetActive(true);
        dialogueVariables.StartListening(currentStory);
        ContinueStory();
        dialogueIsPlaying = true;
      

    }
    private IEnumerator ExitDialougeMode(){
        yield return new WaitForSeconds(0.2f);
        dialogueVariables.StopListening(currentStory);
        Debug.Log("Exited Dialogue");
        dialogueIsPlaying = false;
        firstMessageRead = false;
        dialoguePanel.SetActive(false);
        dialogueText.text="";
    }
    private void ContinueStory(){
        Debug.Log("ran");
        if (currentStory.canContinue){
        
            dialogueText.text=currentStory.Continue();
            displayChoices();
        }
        else{
    
            StartCoroutine(ExitDialougeMode());
        }
    }
    private void displayChoices() {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length) {
            Debug.LogError("More choices were given than can be supported");
        }
        int j = 0;
        foreach (Choice choice in currentChoices) {
            choices[j].gameObject.SetActive(true);
            choicesText[j].text = choice.text;
            j++;
        }
        for (int i = j; i < choices.Length; i++) {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(selectFirstChoice());
    }
    private IEnumerator selectFirstChoice() {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }
    public void MakeChoice(int choiceIndex) {
        currentStory.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }
    public Ink.Runtime.Object GetVariableState(string variableName) {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null) {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }
    // This method will get called anytime the application exits.
    public void OnApplicationQuit() {
        dialogueVariables.SaveVariables();
    }
}
