using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultLoader : MonoBehaviour
{
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI Textnama;
    public GameObject ImageSenang;
    public GameObject ImageSedih;


    float PlayerScore;
    string PlayerName;
    
    void Awake()
    {
        PlayerName = PlayerPrefs.GetString("playerName");
        Textnama.text = "Score\n" + PlayerName + ":\n";
        PlayerScore = PlayerPrefs.GetFloat("score");
        TextScore.text = PlayerScore.ToString();

        if(PlayerScore < 70f)
        {
            ImageSedih.SetActive(true);
        }
        else
        {
            ImageSenang.SetActive(true);
        }
    }
}
