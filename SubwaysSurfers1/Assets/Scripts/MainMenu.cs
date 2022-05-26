using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject StartMenu;
    public AudioMixer musicMixer;

    // Start is called before the first frame update
    void Start()
    {
        StartMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {

        Application.Quit();

    }

    public void StartGame() 
    {

        SceneManager.LoadScene(1);
    
    }

    public void Options() 
    {
        StartMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        
    }

    public void QuitOptions() 
    {
        StartMenu.SetActive(true);
        OptionsMenu.SetActive(false);

    }

    public void SetVolume(float volume)
    {


        musicMixer.SetFloat("volume", volume);

    }

}
