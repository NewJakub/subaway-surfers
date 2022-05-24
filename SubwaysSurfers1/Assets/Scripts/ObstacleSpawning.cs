using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawning : MonoBehaviour
{
    public GameObject obstacle;

    public Transform spawnPos;


    // Start is called before the first frame update
    void Start()
    {
        
        spawnPos.transform.position = new Vector3(0, 0, 100);
        Instantiate(obstacle, spawnPos);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
