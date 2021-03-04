using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EGetSprite : MonoBehaviour
{
    public GameObject GameManager;
    public Image SelectedImage;
    private GameObject Sunit;

    void Update()
    {
        Sunit = GameManager.GetComponent<GameManager>().enemyunit;
        if (Sunit != null)
            SelectedImage.sprite = Sunit.GetComponent<SpriteRenderer>().sprite;
    }
}
