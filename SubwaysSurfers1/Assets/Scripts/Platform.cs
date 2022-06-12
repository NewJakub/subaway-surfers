using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    Transform player;
    public Transform pushPos;

    // Start is called before the first frame update
    void Awake()
    {
        player = PlatformSpawner.instance.player;    
    }

    // Update is called once per frame
    void Update()
    {
        float devidePos = pushPos.transform.position.z - player.transform.position.z;
        if (devidePos <= -250 )
        {
            //platformHolder.transform.GetChild(0).gameObject.transform.position += new Vector3(0, 0, 1000);
            gameObject.transform.position += new Vector3(0, 0, 1600);
            

        }

    }
}
