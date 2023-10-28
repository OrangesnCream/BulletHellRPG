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
    private bool firstMessageRead;
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
        firstMessageRead = false;
        dialoguePanel.SetActive(false);
    }
    private void Update(){
        if(!dialogueIsPlaying){
            return;
        }
        if(Input.GetKeyDown("e")&&firstMessageRead){
            ContinueStory();
        }
        firstMessageRead = true;
    }
    public void EnterDialogueMode(TextAsset inkJSON){
        Debug.Log("Entered Dialogue");
        currentStory =new Story(inkJSON.text);
       
        dialoguePanel.SetActive(true);
        ContinueStory();
        dialogueIsPlaying = true;
      

    }
    private IEnumerator ExitDialougeMode(){
        yield return new WaitForSeconds(0.2f);
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
            Debug.Log(dialogueText.text);
        }
        else{
    
            StartCoroutine(ExitDialougeMode());
        }
    }
}
