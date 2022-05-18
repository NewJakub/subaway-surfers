using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    
    public AudioClip[] clip;
    public static GameManager instance;
    AudioSource audioSrc;

    public Text scoreText;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Score: {score}";
    }

    public void PlaySound(string name) 
    {
        switch (name) {
            
            case "swipeMove":

                audioSrc.PlayOneShot(clip[0]);
            break;


            case "swipeDown":

                audioSrc.PlayOneShot(clip[1]);

                break;


            case "swipeUp":

                audioSrc.PlayOneShot(clip[2]);

                break;
        }
    }
}
