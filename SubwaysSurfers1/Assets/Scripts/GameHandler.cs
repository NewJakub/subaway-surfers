    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;
  
public class GameHandler : MonoBehaviour
{
    public static GameHandler instance;
    public TextAsset jsonText;
    string path;


        
    //[System.Serializable]
    public class OptionsData
    {

       public float sound;

    }
    // Start is called before the first frame update
    void Start()
    {
        path = Application.dataPath + "/TextFiles";
        instance = this;

        OptionsData optionsData = new OptionsData();
        
        

        string json = JsonUtility.ToJson("1");
        File.WriteAllText(path, json);

        //optionsData = JsonUtility.FromJson<OptionsData>(jsonText.text);
        //print(optionsData.sound);
        //AudioListener.volume = optionsData.sound;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
