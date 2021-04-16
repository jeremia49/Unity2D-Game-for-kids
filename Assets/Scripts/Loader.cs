using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Loader : MonoBehaviour
{
    public Image progressbar;
    public TextMeshProUGUI loadingtext;
    public string Scene;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(PlayText());

        AsyncOperation loading = SceneManager.LoadSceneAsync(Scene);
        while (loading.progress < 1)
        {
            progressbar.fillAmount = loading.progress;
            StartCoroutine(PlayText());
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator PlayText()
    {
        if (loadingtext.text == "LOADING...")
        {
            loadingtext.text = "LOADING";
        } else { 
            loadingtext.text = loadingtext.text + ".";
        }
        yield return new WaitForEndOfFrame();
    }



}
