using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    public GameObject gameOverMenu;

    private void Start()
    {
        gameOverMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin") 
        {
            GameManager.instance.score++;
            //Updatuje score
            scoreText.text = $"Score: {GameManager.instance.score}";
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "SlidingObstacle" && !PlayerMovement.instance.isSliding) 
        {

            Die();
        
        }
        if (other.gameObject.tag == "Obstacle") 
        {

            Die();
        
        }

    }

    void Die() 
    {
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
        

    }

}
