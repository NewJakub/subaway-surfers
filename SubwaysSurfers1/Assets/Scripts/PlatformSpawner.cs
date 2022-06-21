using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject[] platforms;
    
    public Transform endPos;
    public Transform platformHolder;
    public Transform player;
    public List<GameObject> pooledObjects = new List<GameObject>();
    public static PlatformSpawner instance;

    int r;
    
    public int poolSize = 10;


    private void Awake()
    {
        instance = this;

        for (int i = 0; i < poolSize; i++)
        {
            r = Random.Range(0, platforms.Length);


            GameObject prefab = Instantiate(platforms[r]);
            pooledObjects.Add(prefab);
            prefab.SetActive(false);


            
            prefab.transform.parent = platformHolder;

        }

    }
    
    void Update()
    {

        if (endPos.transform.position.z - player.transform.position.z <= 500)
        {
            GameObject currentPlatform = instance.GetPooledObject();
           

            if (currentPlatform != null)
            {
                currentPlatform.transform.position = endPos.transform.position;
                currentPlatform.SetActive(true);

                endPos.transform.position += new Vector3(0, 0, 200);

            }
        }
    }


    

    public GameObject GetPooledObject()
    {
        r = Random.Range(0, poolSize);
        GameObject prefab = pooledObjects[r];
        if (!prefab.activeInHierarchy)
        {
            return prefab;
        }
        
        return null;
    }


    //public GameObject GetPlatform()
    //{
    //    //GameObject platformDequeue = pool.Dequeue();
    //    //platformDequeue.SetActive(true);
    //    //return platformDequeue;
    //}

    /*    


    void Update() 
    {

        //Checkuje vzdalenost a podle toho spawnuje nebo nici platformy
        if ( endPos.transform.position.z - player.transform.position.z <= 500) 
        {
            platformHolder.transform.GetChild(0).gameObject.transform.position += new Vector3(0, 0, 1000);

            Spawn();

        }

        if (player.transform.position.z - destroyPos.transform.position.z >= 250)
        {

            PushPlatform();

        }


    }



    void PushPlatform()
    {
        //Destroy(platformHolder.transform.GetChild(0).gameObject);
        platformHolder.transform.GetChild(0).gameObject.transform.position += new Vector3(0, 0, 100); 
        destroyPos.transform.position += new Vector3(0,0,200);
    }

    void Push()
    {
        
        //Platforma se vytvori na pozici a jako child do platform holderu

        //Menime pozici platformi podle toho kde je end pos

        platforms[r].transform.position = endPos.transform.position;

        endPos.transform.position += new Vector3(0, 0, 200);

    }
    */
}
