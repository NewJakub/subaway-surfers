using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platforms;
    
    public Transform endPos;
    public Transform platformHolder;
    public Transform player;
    public Transform destroyPos;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void Update() 
    {

        if ( endPos.transform.position.z - player.transform.position.z <= 500) 
        {

            Spawn();

        }

        if (player.transform.position.z - destroyPos.transform.position.z >= 250)
        {

            Destroy();

        }


    }

    void Spawn() 
    {


        Instantiate(platforms, platformHolder);
        platforms.transform.position = endPos.transform.position;   

        
        
        endPos.transform.position += new Vector3(0, 0, 200);

    }

    void Destroy()
    {

        Destroy(platformHolder.transform.GetChild(0).gameObject);
        destroyPos.transform.position += new Vector3(0,0,200);
    }

}
