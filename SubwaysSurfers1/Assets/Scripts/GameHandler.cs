using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        OptionsData optionsData = new OptionsData();
        optionsData.sound = 1;

        

        string json = JsonUtility.ToJson(optionsData);
        File.WriteAllText(Application.dataPath + "saveFile.json", json);
        print(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    class OptionsData 
    {

        public float sound;
    
    
    }
}
