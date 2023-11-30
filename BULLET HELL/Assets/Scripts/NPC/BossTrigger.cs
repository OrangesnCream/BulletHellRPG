using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    //only activates dialogue prompt UI when player is nearby

    [Header("TriggerVisual")]
    [SerializeField] private GameObject triggerVisual;
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [Header("Last Dialogue JSON")]
    [SerializeField] private TextAsset lastJSON;
    private bool playerInRange;
    private bool dialoguePlayed;
    CameraFollow cameraFollow;
    private void Awake() {
         cameraFollow = Camera.main.GetComponent<CameraFollow>();

        playerInRange = false;
        dialoguePlayed = false;
        triggerVisual.SetActive(false);
    }
    private void Update() {
        if (playerInRange && !DialogueManager.GetInstance().dialogueIsPlaying) {
            triggerVisual.SetActive(true);
           
            if (dialoguePlayed) {
                Debug.Log("playing dialogue");
                // DialogueManager.GetInstance().EnterDialogueMode(lastJSON);
                cameraFollow.isBossCamera = false;
            }
            else {
                cameraFollow.isBossCamera = true;
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
                dialoguePlayed = true;
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
