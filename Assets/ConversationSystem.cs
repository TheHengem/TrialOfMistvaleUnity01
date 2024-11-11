using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
using TMPro;

public class ConversationSystem : MonoBehaviour
{
    private PauseMenu pauseMenu;
    public NPCConversation conversation01;
    public string playerTag = "Player";
    // Start is called before the first frame update
    private bool isTalking = false;

    void Awake()
    {
        pauseMenu = GetComponent<PauseMenu>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTalking();
        if (Input.GetKeyDown(KeyCode.E))
                {
                    isTalking = true;
                    ConversationManager.Instance.StartConversation(conversation01);
                }
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag(playerTag))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ConversationManager.Instance.StartConversation(conversation01);
                }
            }
    }
    private void CheckIfTalking()
    {
        if (isTalking)
        {
            pauseMenu.isPaused = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
