using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Unity.Mathematics;

public class PauseSystem : MonoBehaviour
{
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    private bool canPause = true;
    private void Awake() 
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (starterAssetsInputs.pause && canPause)
        {
            PauseGame();
        }
        
    void PauseGame ()
    {
        Time.timeScale = 0;
    }

    void ResumeGame ()
    {
        Time.timeScale = 1;
    }
    
    }
}
