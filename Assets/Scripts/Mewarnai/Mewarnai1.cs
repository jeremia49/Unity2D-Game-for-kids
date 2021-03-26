using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mewarnai1 : MonoBehaviour
{
    public Color[] colorList;
    public Color currColor;
    public int colorindex;
    public GameObject ParentObject;
    public Color DefaultColor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currColor = colorList[colorindex];

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            RaycastHit2D hit = Physics2D.Raycast(touchPos, -Vector2.up);

            if (hit.collider != null)
            {
                SpriteRenderer sp = hit.collider.gameObject.GetComponent<SpriteRenderer>();
                sp.color = currColor;
            }
        }
    }

    public void SetColor(int ColorIndex)
    {
        colorindex = ColorIndex;
    }

    public void ResetColor()
    {
        int childcount = ParentObject.transform.childCount;
        for (int i = 0; i < childcount; i++)
        {
            GameObject childcomp = ParentObject.transform.GetChild(i).gameObject;
            SpriteRenderer sp = childcomp.GetComponent<SpriteRenderer>();
            sp.color = DefaultColor;
        }
    }

}
