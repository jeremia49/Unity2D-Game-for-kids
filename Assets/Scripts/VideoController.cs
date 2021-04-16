using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoplayer;
    private Text text;

    private void Start()
    {
        text = this.GetComponentInChildren<UnityEngine.UI.Text>();
    }
    public void playpause()
    {
        if(text.text == "Putar")
        {
            videoplayer.Play();
            text.text = "Jeda";
        }
        else
        {
            videoplayer.Pause();
            text.text = "Putar";
        }
    }

}
