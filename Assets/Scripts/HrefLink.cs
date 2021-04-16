using UnityEngine;

public class HrefLink : MonoBehaviour
{

    public void linkTo(string urlnya) {
        Application.OpenURL(urlnya);
    }
}
