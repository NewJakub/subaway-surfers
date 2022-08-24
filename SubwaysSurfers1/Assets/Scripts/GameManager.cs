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

    private void Start()
    {
        
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

            case "coin_1":

                audioSrc.PlayOneShot(clip[3]);

                break;

            case "coin_2":

                audioSrc.PlayOneShot(clip[4]);

                break;

            case "coin_3":

                audioSrc.PlayOneShot(clip[5]);

                break;


            default:
                Debug.LogWarning("Sound does not exist");
                break;
        }
    }


}
