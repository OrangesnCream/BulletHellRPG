using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {
    //only activates dialogue prompt UI when player is nearby

    [Header("TriggerVisual")]
    [SerializeField] private GameObject triggerVisual;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    private bool playerInRange;
    private void Awake() {

 
        playerInRange = false;
        triggerVisual.SetActive(false);
    }
    private void Update() {
        if (playerInRange) {
            triggerVisual.SetActive(true);
            if (Input.GetKeyDown("e")){
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }

        }
        else {
            triggerVisual.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerInRange = true;
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            playerInRange = false;
        }

    }

}
