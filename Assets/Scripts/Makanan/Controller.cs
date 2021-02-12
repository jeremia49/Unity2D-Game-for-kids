using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject[] listobject;

    public GameObject KotakSehat;
    public GameObject KotakBuruk;

    public GameObject CekScoreButton;


    //public int[] listMakananSehat;
    //public int[] listMakananBuruk;


    public float Score;

    float deltaX, deltaY;
    bool moveAllowed = false;
    int lastidbox = 0;
    int lastindex = -1;

    float tolerance = 1;
    float boxtolerance = 3f;

    struct Position
    {
        public float posx;
        public float posy;
        public float posz;


        public Position(float x, float y, float z)
        {
            this.posx = x;
            this.posy = y;
            this.posz = z;
        }
    }



    void Awake()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        Position[] OriginalPosition = new Position[listobject.Length];

        for (int i = 0; i < listobject.Length; i++)
        {
            GameObject box = listobject[i].gameObject;
            Position TempPos = new Position(box.transform.position.x, box.transform.position.y, box.transform.position.z);
            OriginalPosition[i] = TempPos;
        }

        reshuffle(OriginalPosition);

        for (int i = 0; i < listobject.Length; i++)
        {
            Position chPos = OriginalPosition[i];
            GameObject box = listobject[i].gameObject;
            box.transform.position = new Vector3(chPos.posx, chPos.posy, chPos.posz);
        }

        Debug.Log(OriginalPosition);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    for (int i = 0; i < this.listobject.Length; i++)
                    {
                        GameObject box = this.listobject[i].gameObject;
                        if (touchPos.x >= box.transform.position.x - tolerance && touchPos.x <= box.transform.position.x + tolerance && touchPos.y >= box.transform.position.y - tolerance && touchPos.y <= box.transform.position.y + tolerance)
                        {
                            deltaX = touchPos.x - box.transform.position.x;
                            deltaY = touchPos.x - box.transform.position.y;

                            lastindex = i;
                            lastidbox = box.GetComponent<Identifier>().IDBOX;
                            moveAllowed = true;
                            Debug.Log("Got Clicked");
                            Debug.Log("BOX ID : " + box.GetComponent<Identifier>().IDBOX.ToString());
                            break;
                        }
                    }
                    break;
                case TouchPhase.Moved:
                    if (moveAllowed && lastidbox != 0 && lastindex != -1)
                    {
                        GameObject box = listobject[lastindex].gameObject;
                        Debug.Log("Moving Box " + box.GetComponent<Identifier>().IDBOX.ToString());
                        box.transform.position = new Vector3(touchPos.x - deltaX, touchPos.y, -8.0f);
                    }
                    break;
                case TouchPhase.Ended:
                    lastidbox = 0;
                    lastindex = -1;
                    moveAllowed = false;
                    break;
            }

        }

        int benar = 0;
        int jawab = 0;

        for (int i = 0; i < listobject.Length; i++)
        {
            GameObject box = listobject[i].gameObject;
            int indikator = box.GetComponent<Identifier>().Indikator;


            if ((box.transform.position.x >= KotakBuruk.transform.position.x - boxtolerance && box.transform.position.x <= KotakBuruk.transform.position.x + boxtolerance && box.transform.position.y >= KotakBuruk.transform.position.y - boxtolerance && box.transform.position.y <= KotakBuruk.transform.position.y + boxtolerance) || (box.transform.position.x >= KotakSehat.transform.position.x - boxtolerance && box.transform.position.x <= KotakSehat.transform.position.x + boxtolerance && box.transform.position.y >= KotakSehat.transform.position.y - boxtolerance && box.transform.position.y <= KotakSehat.transform.position.y + boxtolerance))
            {
                jawab++;

                if (indikator == 1)
                {
                    if (box.transform.position.x >= KotakBuruk.transform.position.x - boxtolerance && box.transform.position.x <= KotakBuruk.transform.position.x + boxtolerance && box.transform.position.y >= KotakBuruk.transform.position.y - boxtolerance && box.transform.position.y <= KotakBuruk.transform.position.y + boxtolerance)
                    {
                        benar += 1;
                    }

                }
                else if (indikator == 2)
                {
                    if (box.transform.position.x >= KotakSehat.transform.position.x - boxtolerance && box.transform.position.x <= KotakSehat.transform.position.x + boxtolerance && box.transform.position.y >= KotakSehat.transform.position.y - boxtolerance && box.transform.position.y <= KotakSehat.transform.position.y + boxtolerance)
                    {
                        benar += 1;
                    }
                }
            }
        }
        Score = (benar * 100f / listobject.Length);
        PlayerPrefs.SetFloat("score", Score);

        if (jawab == listobject.Length) {
            CekScoreButton.SetActive(true);
        }
        else {
            CekScoreButton.SetActive(false);
        }



    }

    void reshuffle(Position[] texts)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < texts.Length; t++)
        {
            Position tmp = texts[t];
            int r = Random.Range(t, texts.Length);
            texts[t] = texts[r];
            texts[r] = tmp;
        }
    }


    public void CheckScore()
    {
        SceneManager.LoadSceneAsync("Result");
    }
}



