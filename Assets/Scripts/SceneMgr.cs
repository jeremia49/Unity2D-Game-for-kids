using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMgr : MonoBehaviour
{

    public void telTO(string To)
    {
        if (To == "Quit")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadSceneAsync(To);
        }
    }
 
}
        
