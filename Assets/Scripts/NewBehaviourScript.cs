using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    private bool isGrounded = false;
    private bool hitJump = false;
    private bool isJumping;
    public float dashSpeed = 30f;
    private bool isDashing = false;
    public float dashForce = 20f;
    public float moveSpeed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
   
    private void FixedUpdate()
    {
        Dash();
    }
    private void Dash()
    {
        if (Input.GetKey(KeyCode.LeftControl) && isGrounded == false)
        {
            StartCoroutine(DoDash());
        }
    }
    private IEnumerator DoDash()
    {
        isDashing = true;
        moveSpeed = dashSpeed;
        yield return new WaitForSeconds(1f);
        dashSpeed = moveSpeed;
        isDashing = false;
        isGrounded = true;
    }
}
