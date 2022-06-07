    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;
  
public class GameHandler : MonoBehaviour
{
    public class SaveData : MonoBehaviour
    {
        public float sound;
        
    }


    string directory = "/TextFiles/";
    string fileName = "MyData.txt";
    

    
    public TextAsset myData;
    //[System.Serializable]


    
    // Start is called before the first frame update
    void Start()
    {

        SaveData sd = new SaveData() { sound = 0.5f };
        sd.name = "Max";
        sd.sound = 0.5f;
        string dir = Application.dataPath + directory;
        //Directory.CreateDirectory(dir);
        

        
        
        

        string json = JsonUtility.ToJson(sd);
        File.WriteAllText(dir + fileName, json);


        //print(optionsData.sound);
        //AudioListener.volume = optionsData.sound;
        SaveData loadData =  JsonUtility.FromJson<SaveData>(json);
        print(loadData.sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
