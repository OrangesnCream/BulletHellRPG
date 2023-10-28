using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }
    private static DialogueManager instance;
    private void Awake(){
        if(instance!=null){
            Debug.LogWarning("Found multiple dialogue managers");
        }
        instance=this;
    }
    public static DialogueManager GetInstance(){
        return instance;
    }
    private void Start(){
        dialogueIsPlaying=false;
        dialoguePanel.SetActive(false);
    }
    private void Update(){
        if(!dialogueIsPlaying){
            return;
        }
        if(Input.GetKeyDown("e")){
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON){
      
        currentStory=new Story(inkJSON.text);
        dialogueIsPlaying=true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }
    private void ExitDialougeMode(){
        Debug.Log("Exited Dialogue");
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text="";
    }
    private void ContinueStory(){
        Debug.Log("ran");
        if (currentStory.canContinue){
            Debug.Log("Entered Dialogue");
            dialogueText.text=currentStory.Continue();
            Debug.Log(dialogueText.text);
        }
        else{
    
            ExitDialougeMode();
        }
    }
}
