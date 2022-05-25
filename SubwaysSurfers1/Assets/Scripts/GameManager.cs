using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int score = 0;
    
    [SerializeField] AudioClip[] clip;
    AudioSource audioSrc;

    public static GameManager instance;
    
    
    void Awake()
    {
        instance = this;
        audioSrc = GetComponent<AudioSource>();
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
