using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FirstRun : MonoBehaviour
{
    public TMP_InputField Inputtext;
    public TextMeshProUGUI ErrorText;

    string PlayerName;

    void Awake()
    {
        Inputtext.interactable = true;
    }

    public void SubmitData()
    {
        if(Inputtext.text == "")
        {
            ErrorText.text = "Nama Tidak Boleh Kosong !";
        }
        else
        {
            PlayerName = Inputtext.text;
            PlayerPrefs.SetString("playerName", PlayerName);
            SceneManager.LoadSceneAsync("Menu");
        }
    }



}
