using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{   
    [SerializeField]
    Slider slider;
    public static GameHandler instance;


    public string directory = "/TextFiles/";
    const string fileName = "MyData.txt";


    public TextAsset myData;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {

        

        string dir = Application.dataPath + directory;

        //Prevadime SaveData sd na JSON
        

        
        string readFile = File.ReadAllText(dir + fileName);
        //Prevadime z JSON
        SaveData loadData =  JsonUtility.FromJson<SaveData>(readFile);

        AudioListener.volume = loadData.sound;

        //Slider se setuje na zacatecni pozici
        slider.value = loadData.sound;
        

        

    }

    public void SetVolume(float volume)
    {
        SaveData sd = new SaveData() { sound = 0 };

        AudioListener.volume = slider.value;
        sd.sound = AudioListener.volume;

        string dir = Application.dataPath + directory;
        string json = JsonUtility.ToJson(sd);
        //Prepisujeme data
        File.WriteAllText(dir + fileName, json);
    }
}
