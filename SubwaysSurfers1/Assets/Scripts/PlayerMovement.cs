using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public LayerMask groundLayers;
 

    const float speed = 5;
    const float jumpForce = 7;

    float height;
    public float crouchedHeight;

    private Rigidbody rb;
    private CapsuleCollider col;

    public Animator maxAnimator;

    #region Monobehaviour API

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();

        height = col.height;
    }

    void Update()
    {

        Vector3 movement = new Vector3(0, rb.velocity.y, 1 * speed);           
        rb.velocity = movement;



        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            maxAnimator.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            GameManager.instance.PlaySound("swipeUp");
        }

        if (!Input.GetKeyDown(KeyCode.Space))
        {
            maxAnimator.SetBool("isJumping", false);
            


        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            Crouch();
            maxAnimator.SetBool("isSliding", true);
            GameManager.instance.PlaySound("swipeDown");
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {

            StandUp();
            maxAnimator.SetBool("isSliding", false);
        }

    }

    private bool IsGrounded()
    {
        
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);

    }

    #endregion

    void Crouch() 
    { 
        col.height = crouchedHeight;

    
    }

    void StandUp() 
    {

        col.height = height;
    
    }

}
