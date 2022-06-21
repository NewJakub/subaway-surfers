using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSides : MonoBehaviour
{

    [SerializeField]
    GameObject player;

    Animator maxAnimator;
    
    int positionNum;
    float subtractionNum;

    Vector2 startMousePos;
    Vector2 endMousePos;



    private void Start()
    {
        maxAnimator = GetComponent<Animator>();
        
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Mouse0) && !PlayerScript.instance.isDead) 
        {
            startMousePos = Input.mousePosition;
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse0) && !PlayerScript.instance.isDead) 
        {

            endMousePos = Input.mousePosition;
            subtractionNum = startMousePos.x - endMousePos.x;
        }

        #region CharacterMove
        if (subtractionNum < 0  && positionNum > -1) 
        {
            //Jde do prava

            positionNum--;

            Vector3 temp = new Vector3(5, 0, 0);
            player.transform.position += temp;
            maxAnimator.SetBool("goingRight", true);
            SetZero();
        }
        else
        {
            maxAnimator.SetBool("goingRight", false);
        }
        if (subtractionNum > 0 && positionNum < 1)
        {
            //Jde do leva

            positionNum++;

            Vector3 temp = new Vector3(-5, 0, 0);
            player.transform.position += temp;
            maxAnimator.SetBool("goingLeft", true);
            SetZero();
        }
        else 
        {
            maxAnimator.SetBool("goingLeft", false);
        }
        #endregion

    }


    void SetZero() 
    {
        //Setuje mouse pos na 0 a hraje zvuk
        subtractionNum = 0;
        startMousePos.x = 0f;
        endMousePos.x = 0f;
        GameManager.instance.PlaySound("swipeMove");
    }

}
