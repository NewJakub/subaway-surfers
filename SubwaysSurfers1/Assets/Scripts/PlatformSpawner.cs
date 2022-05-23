using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;
    
    public Transform endPos;
    public Transform setPos;
    public Transform platformHolder;
    public GameObject platformSpawner;
    int r = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1,1);
    }


    void Spawn() 
    {


        Instantiate(setPos, platformHolder);
        setPos.transform.position = endPos.transform.position;

        r = Random.Range(0, 6);

        Instantiate(platforms[r], setPos);
        
        endPos.transform.position += new Vector3(0, 0, 200);

    }

}
