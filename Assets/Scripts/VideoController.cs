using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoController : MonoBehaviour
{
    public UnityEngine.Video.VideoPlayer videoplayer;
    private Text text;

    private void Awake()
    {
        videoplayer.Prepare();
    }

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
    public void forward()
    {
        if (videoplayer.clip.length < videoplayer.time - 10f)
        {
            videoplayer.time = videoplayer.clip.length - 10f;
        }
        else
        {
            videoplayer.time += 10f;
        }
    }

    public void backward()
    {
        if (videoplayer.time < 10) {
            videoplayer.time = 0f;
        }
        else
        {
            videoplayer.time -= 10f;
        }
    }



}
