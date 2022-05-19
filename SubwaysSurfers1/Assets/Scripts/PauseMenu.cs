using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (pauseMenu.active == false && Input.GetKeyDown(KeyCode.Escape)) 
        {

            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) 
        {

            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }


    }

    public void RestartGame() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    
    }

    public void QuitGame() 
    {

        Application.Quit();
    
    }

}
