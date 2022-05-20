using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    GameObject endPosEmptyObject;
    Transform endPos;
    public GameObject platformSpawner;
    Vector3 plusVector = new Vector3(0, 0, 50);

    int spawnPos = 0;
    // Start is called before the first frame update
    void Start()
    {
        endPosEmptyObject = gameObject.transform.GetChild(0).gameObject;
        endPos = endPosEmptyObject.transform.GetChild(2).transform;



        

        //platform.transform.parent = platformSpawner.transform;
        Instantiate(platform, endPos);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlatformSpawn() 
    {

        yield return new WaitForSeconds(1);

    }

}
