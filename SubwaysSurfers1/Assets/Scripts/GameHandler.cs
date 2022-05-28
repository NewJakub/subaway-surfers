using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Audio;
  
public class GameHandler : MonoBehaviour
{
    static GameHandler instance;
    public TextAsset jsonText;
    
        
    //[System.Serializable]
    public class OptionsData
    {

       public float sound;

    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        OptionsData optionsData = new OptionsData();
        AudioListener.volume = optionsData.sound;
        

        string json = JsonUtility.ToJson(optionsData);
        File.WriteAllText(Application.dataPath + "/TextFiles/JSONText.json", json);

        optionsData = JsonUtility.FromJson<OptionsData>(jsonText.text);
        print(optionsData.sound);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
