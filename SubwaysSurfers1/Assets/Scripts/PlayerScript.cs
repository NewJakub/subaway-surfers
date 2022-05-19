using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin") 
        {
            GameManager.instance.score++;
            //Updatuje score
            scoreText.text = $"Score: {GameManager.instance.score}";
            Destroy(other.gameObject);
        }
    }

}
