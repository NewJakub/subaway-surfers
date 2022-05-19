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

    #region 

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


        # region JumpingRegion
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            maxAnimator.SetBool("isJumping", true);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            GameManager.instance.PlaySound("swipeUp");
        }

        else if (!Input.GetKeyDown(KeyCode.Space))
        {
            maxAnimator.SetBool("isJumping", false);

        }
        #endregion

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(SlideTiming());

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {

            StopCoroutine(SlideTiming());
        }

    }

    private bool IsGrounded()
    {

        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);

    }

    #endregion

    void Slide()
    {
        col.height = crouchedHeight;
        maxAnimator.SetBool("isSliding", true);
        GameManager.instance.PlaySound("swipeDown");

    }

    void StandUp()
    {

        col.height = height;
        maxAnimator.SetBool("isSliding", false);
    }


    IEnumerator SlideTiming() 
    {
        Slide();
        

        yield return new WaitForSeconds(1f);
        StandUp();
        
    }
} 


