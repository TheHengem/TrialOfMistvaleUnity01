using DialogueEditor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{
    private bool playerInZone = false;
    private PauseMenu pauseMenuReference;
    public NPCConversation conversation01;
    private bool isTalking = false;


    void Awake()
    {
        pauseMenuReference = GameObject.Find("PauseMenuScriptHolder").GetComponent<PauseMenu>();
    }

    // This method is called when another collider enters the trigger zone.
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger is the player.
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
            Debug.Log("Player entered the interaction zone.");
        }
    }

    // This method is called when another collider exits the trigger zone.
    private void OnTriggerExit(Collider other)
    {
        // Check if the object exiting the trigger is the player.
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
            Debug.Log("Player left the interaction zone.");
        }
    }

    // Update is called once per frame.
    private void Update()
    {
        // CheckIfTalking();
        // Check if the player is in the zone and presses the "E" key.
        if (playerInZone && Input.GetKeyDown(KeyCode.E))
        {
            ConversationManager.Instance.StartConversation(conversation01);
            Debug.Log("Opening Dialogue");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
    // private void CheckIfTalking()
    // {
    //     if (isTalking)
    //     {
    //         pauseMenuReference.showMouse = true;
    //     }
    // }

    // public void HidingMouse()
    // {
    //     pauseMenuReference.showMouse = false;
    // }
}