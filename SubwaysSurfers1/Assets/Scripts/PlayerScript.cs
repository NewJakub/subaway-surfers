using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin") 
        {
            GameManager.instance.score++;
            Destroy(other.gameObject);
        }
    }

}
