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
    public List<GameObject> pooledObjects = new List<GameObject>();
    public static PlatformSpawner instance;

    

    public Queue<GameObject> pool = new Queue<GameObject>();
    
    public int poolSize = 3;


    private void Awake()
    {
        instance = this;

        

    }
    private void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            


            GameObject prefab = Instantiate(platforms);
            pooledObjects.Add(prefab);
            prefab.SetActive(false);
            

            //prefab.transform.position = endPos.transform.position;
            //endPos.transform.position += new Vector3(0, 0, 200);
            prefab.transform.parent = platformHolder;

        }
    }
    void Update()
    {

        //Checkuje vzdalenost a podle toho spawnuje nebo nici platformy
        if (endPos.transform.position.z - player.transform.position.z <= 500)
        {
            GameObject currentPlatform = instance.GetPooledObject();
            //platformHolder.transform.GetChild(0).gameObject.transform.position += new Vector3(0, 0, 1000);

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
        
        for (int i = 0; i < poolSize; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
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
