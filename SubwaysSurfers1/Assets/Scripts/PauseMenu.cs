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

        //Checkuje jestli je pause menu active
        if (pauseMenu.activeInHierarchy == false && Input.GetKeyDown(KeyCode.Escape)) 
        {

            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) 
        {

            ResumeGame();
        }


    }

    public void RestartGame() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    
    }

    public void QuitGame() 
    {

        Application.Quit();
    
    }

    public void ResumeGame()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios) 
        {

            a.Play();
        
        }
    }
    void PauseGame() 
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {

            a.Pause();


        }


    }
}
