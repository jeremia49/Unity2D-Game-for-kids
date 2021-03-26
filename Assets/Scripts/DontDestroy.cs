using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    void Awake()
    {
        if(GameObject.FindObjectsOfType<AudioSource>().Length == 1) { 
            DontDestroyOnLoad(transform.gameObject);
            if (transform.GetComponent<AudioSource>().isPlaying != true)
            {
                transform.GetComponent<AudioSource>().Play();
            }
        }
    }

    void Update()
    {
        if (GameObject.FindObjectsOfType<UnityEngine.Video.VideoPlayer>().Length >= 1 && transform.GetComponent<AudioSource>().isPlaying == true)
        {
            transform.GetComponent<AudioSource>().Pause();
        }else if(GameObject.FindObjectsOfType<UnityEngine.Video.VideoPlayer>().Length == 0 && transform.GetComponent<AudioSource>().isPlaying == false)
        {
            transform.GetComponent<AudioSource>().Play();
        }
        
    }

}
