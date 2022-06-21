using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    
    public Text scoreText;
    public GameObject gameOverMenu;
    public static PlayerScript instance;

    public bool isDead = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOverMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.instance.score++;
            //Updatuje score
            scoreText.text = $"Score: {GameManager.instance.score}";
            Destroy(other.gameObject);
        }

        //Pro prekazky u kterych se da slidovat
        if (other.CompareTag("SlidingObstacle")  && !PlayerMovement.instance.isSliding || other.CompareTag("Obstacle")) 
        {

            Die();
        
        }

    }

    void Die() 
    {
        isDead = true;
        Time.timeScale = 0;
        gameOverMenu.SetActive(true);
        

    }

}
