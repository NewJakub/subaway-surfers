using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    
    public Transform endPos;
    public Transform setPos;
    public Transform bruh;
    public GameObject platformSpawner;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1,1);
        
    }


    void Spawn() 
    {


        Instantiate(setPos, bruh);
        setPos.transform.position = endPos.transform.position;

        Instantiate(platform, setPos);
        
        endPos.transform.position += new Vector3(0, 0, 200);

    }

}
