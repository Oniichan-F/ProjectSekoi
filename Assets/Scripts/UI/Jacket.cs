using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jacket : MonoBehaviour
{
    public void ChangeJacket()
    {
        string path = "Images/Jackets/" + GameManager.gameManager.songSourceName + "_jacket";
        Sprite image = Resources.Load<Sprite>(path);
        GetComponent<Image>().sprite = image;
        Debug.Log(path);
    }
}
