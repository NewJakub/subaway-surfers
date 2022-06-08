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

    

    // Start is called before the first frame update
    void Start()
    {
        StartMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }


    public void Quit()
    {

        Application.Quit();

    }

    public void StartGame() 
    {
        //Loaduje scenu
        SceneManager.LoadScene(1);
    
    }

    public void Options() 
    {
        //Aktivuje optioons menu
        StartMenu.SetActive(false);
        OptionsMenu.SetActive(true);
        
    }

    public void QuitOptions() 
    {
        //Deaktivuje options menu
        StartMenu.SetActive(true);
        OptionsMenu.SetActive(false);
    }

   

}
