using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using Unity.Mathematics;

public class Spellcraft : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSenstivity;
    [SerializeField] private float aimSenstivity;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;
    private Animator animator;
    private bool canCast = false;
    

    private void Awake() 
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        animator = GetComponent<Animator>();

    }

    private void Update() 
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
    Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint); 
    if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
    {
        // debugTransform.position = raycastHit.point;
        mouseWorldPosition = raycastHit.point;
    }

        if (starterAssetsInputs.aim)
        {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Debug.Log("Aiming and Hiding Mouse");
        canCast = true;
        aimVirtualCamera.gameObject.SetActive(true);
        thirdPersonController.SetSensitivity(aimSenstivity);
        crosshair.gameObject.SetActive(true);
        thirdPersonController.setRotateOnMove(false);
        animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 1f, Time.deltaTime * 10f));

        Vector3 worldAimtarget = mouseWorldPosition;
        worldAimtarget.y = transform.position.y;
        Vector3 aimDirection = (worldAimtarget - transform.position).normalized;

        transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);
        }
        else 
        {
        canCast = false;
        aimVirtualCamera.gameObject.SetActive(false);
        thirdPersonController.SetSensitivity(normalSenstivity);
        crosshair.gameObject.SetActive(false);
        thirdPersonController.setRotateOnMove(true);
        animator.SetLayerWeight(1, Mathf.Lerp(animator.GetLayerWeight(1), 0f, Time.deltaTime * 10f));
        }

        if (starterAssetsInputs.shoot && canCast)
        {
            Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
           Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
           starterAssetsInputs.shoot = false;
        }



    }
  
}
