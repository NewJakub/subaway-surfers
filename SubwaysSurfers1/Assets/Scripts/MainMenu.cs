using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.IO;
public class MainMenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject StartMenu;

    public Slider slider;

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

        AudioListener.volume = slider.value;
        //musicMixer.SetFloat("volume", volume);
        string json = JsonUtility.ToJson(slider.value);
        File.WriteAllText(Application.dataPath + "/TextFiles/JSONText.json", json);
    }

}
