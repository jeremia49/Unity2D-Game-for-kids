using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultLoader : MonoBehaviour
{
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI Textnama;

    float PlayerScore;
    string PlayerName;
    
    void Awake()
    {
        PlayerName = PlayerPrefs.GetString("playerName");
        Textnama.text = "Score\n" + PlayerName + ":\n";
        PlayerScore = PlayerPrefs.GetFloat("score");
        TextScore.text = PlayerScore.ToString();
    }
}
