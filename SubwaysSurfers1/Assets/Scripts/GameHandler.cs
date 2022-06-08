    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameHandler : MonoBehaviour
{
    public Slider slider;
    public static GameHandler instance;
    public class SaveData 
    {

        public float sound;
        
    }


    public string directory = "/TextFiles/";
    string fileName = "MyData.txt";



    public TextAsset myData;
    

    public void Start()
    {

        SaveData sd = new SaveData() { sound = 0 };


        string dir = Application.dataPath + directory;






        string json = JsonUtility.ToJson(sd);
        //File.WriteAllText(dir + fileName, json);

        
        string readFile = File.ReadAllText(dir + fileName);
        SaveData loadData =  JsonUtility.FromJson<SaveData>(readFile);

        AudioListener.volume = loadData.sound;

        slider.value = loadData.sound;
        print(loadData.sound);

        

    }

    private void Awake()
    {
        instance = this;
    }

    public void SetVolume(float volume)
    {
        SaveData sd2 = new SaveData() { sound = 0 };
        AudioListener.volume = slider.value;
        sd2.sound = AudioListener.volume;

        string dir = Application.dataPath + directory;
        string json = JsonUtility.ToJson(sd2);
        File.WriteAllText(dir + fileName, json);

        //musicMixer.SetFloat("volume", volume);
        //string json = JsonUtility.ToJson(slider.value);
        //File.WriteAllText(Application.dataPath + "/TextFiles/JSONText.json", json);
    }
}
