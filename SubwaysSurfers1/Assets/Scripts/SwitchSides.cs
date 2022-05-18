using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSides : MonoBehaviour
{

    private Rigidbody rb;
    private SphereCollider col;

    public GameObject player;

    Animator maxAnimator;
    
    Vector3[] positions = 
        {
            new Vector3(5,0,0),
            new Vector3(0,0,0),
            new Vector3(-5,0,0)

        };
    int positionNum = 0;
    Vector2 startMousePos;
    Vector2 endMousePos;
    float odecteni = 0;

    private void Awake()
    {
        
    }

    private void Start()
    {
        positions[0] = new Vector3(5, player.transform.position.y,0);
        positions[1] = new Vector3(0, player.transform.position.y, 0);
        positions[2] = new Vector3(-5, player.transform.position.y, 0);


        rb = GetComponent<Rigidbody>();
        col = GetComponent<SphereCollider>();
        maxAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            startMousePos = Input.mousePosition;
            
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)) 
        {

            endMousePos = Input.mousePosition;
            odecteni = startMousePos.x - endMousePos.x;
        }


        if (odecteni < 0  && positionNum > -1) 
        {
            positionNum--;
            transform.position = positions[positionNum + 1];
            maxAnimator.SetBool("goingRight", true);
            odecteni = 0f;
            startMousePos.x = 0f;
            endMousePos.x = 0f;
            GameManager.instance.PlaySound("swipeMove");
        }
        else
        {
            maxAnimator.SetBool("goingRight", false);
        }
        if (odecteni > 0 && positionNum < 1)
        {
            positionNum++;
            transform.position = positions[positionNum + 1];
            maxAnimator.SetBool("goingLeft", true);
            odecteni = 0;
            startMousePos.x = 0f;
            endMousePos.x = 0f;
            GameManager.instance.PlaySound("swipeMove");
        }
        else 
        {
            maxAnimator.SetBool("goingLeft", false);
        }

    }

   
}
