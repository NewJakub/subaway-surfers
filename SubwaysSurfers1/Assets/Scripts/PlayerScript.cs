using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    public Text scoreText;
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

        //Pro prekazky u kterych se da slidovat
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
