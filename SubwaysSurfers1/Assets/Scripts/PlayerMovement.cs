using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public LayerMask groundLayers;


    const float speed = 40;
    const float jumpForce = 7;

    float height;
    public float crouchedHeight;

    Rigidbody rb;
    CapsuleCollider col;
    Animator maxAnimator;

    public bool isSliding = false;
     


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        maxAnimator = GetComponent<Animator>();

        height = col.height;
        instance = this;
    }

    void Update()
    {

        rb.velocity = new Vector3(0, rb.velocity.y, 1 * speed);
        

        # region JumpingRegion
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && !isSliding)
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


        //Spousti couroutine pokud je zmacknuty shift
        if (Input.GetKeyDown(KeyCode.LeftShift) && IsGrounded())
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
        //Checkuje jestli je na zemi
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);

    }

    

    #region SlidingSetupRegion

    void Slide()
    {
        isSliding = true;
        col.height = crouchedHeight;
        maxAnimator.SetBool("isSliding", true);
        GameManager.instance.PlaySound("swipeDown");

    }

    void StandUp()
    {

        col.height = height;
        maxAnimator.SetBool("isSliding", false);
        isSliding = false;
    }


    IEnumerator SlideTiming() 
    {
        Slide();
        

        yield return new WaitForSeconds(1f);
        StandUp();
        
    }

    #endregion

}


