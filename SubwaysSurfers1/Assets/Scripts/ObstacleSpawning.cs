using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawning : MonoBehaviour
{
    public GameObject[] obstacle;

    public Transform spawnPos;
    public Transform obstacleSpawning;

    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        
        spawnPos.transform.position = new Vector3(0, 0, 200);

        
        InvokeRepeating("SpawnObject", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject() 
    {
        int r = Random.RandomRange(0, 4);
        

        Instantiate(obstacle[r  ], obstacleSpawning);
        gameObject.transform.GetChild(i).transform.position = spawnPos.transform.position;

        i++;
        spawnPos.transform.position += new Vector3(0, 0, 100);
    }

}