using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public LayerMask groundLayers;

    Vector2 startMousePos;
    Vector2 endMousePos;

    const float speed = 40;
    const float jumpForce = 7;

    float height;
    public float crouchedHeight;

    CharacterController con;
    CapsuleCollider col;
    Animator maxAnimator;

    public bool isSliding = false;

    float subtractionNum;
    float positionNum;
    void Start()
    {
        con = GetComponent<CharacterController>();
        col = GetComponent<CapsuleCollider>();
        maxAnimator = GetComponent<Animator>();

        height = col.height;
        instance = this;
    }

    void Update()
    {

        Vector3 moveVector = Vector3.zero;
        moveVector.z = speed;


        con.Move(moveVector * Time.deltaTime);
        

        # region JumpingRegion
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space) && !isSliding)
        {
            Jump();
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

        //lllllllllllllllllllllllllllllllllllll

        if (Input.GetKeyDown(KeyCode.Mouse0) && !PlayerScript.instance.isDead )
        {
            startMousePos = Input.mousePosition;
            print(subtractionNum);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && !PlayerScript.instance.isDead )
        {

            endMousePos = Input.mousePosition;
            subtractionNum = startMousePos.y - endMousePos.y;
            print(subtractionNum);
        }

        if ( subtractionNum > -40)
        {

            subtractionNum = 0;
            SetZero();
        }
       

        #region CharacterMove
        
        
        
        
        #endregion
    }


    private bool IsGrounded()
    {
        //Checkuje jestli je na zemi
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);

    }

    

    void Jump()
    {
        maxAnimator.SetBool("isJumping", true);
       

        GameManager.instance.PlaySound("swipeUp");
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


    void SetZero()
    {
        //Setuje mouse pos na 0 a hraje zvuk
        subtractionNum = 0;
        startMousePos.x = 0f;
        endMousePos.x = 0f;
        GameManager.instance.PlaySound("swipeMove");
    }
}


