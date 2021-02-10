using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{

    public string QuitTo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            if(QuitTo == "Quit") { 
                Application.Quit();
            }
            else
            {
                SceneManager.LoadSceneAsync(QuitTo);
            }
        }
    }
}
