    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;
  
public class GameHandler : MonoBehaviour
{

    string path;
    string directory = "/TextFiles/";
    string fileName = "MyData.txt";

    public SaveData sd;
    //[System.Serializable]
   
    // Start is called before the first frame update
    void Start()
    {
        SaveData sd = new SaveData();
        sd.name = "Max";
        sd.sound = 0.5f;
        string dir = Application.dataPath + directory;
        //Directory.CreateDirectory(dir);
        

        
        
        

        string json = JsonUtility.ToJson(sd);
        File.WriteAllText(dir + fileName, json);

        //optionsData = JsonUtility.FromJson<OptionsData>(jsonText.text);
        //print(optionsData.sound);
        //AudioListener.volume = optionsData.sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
