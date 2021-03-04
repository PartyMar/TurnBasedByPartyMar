using UnityEngine;
using UnityEngine.UI;

public class GetSpritePlayer : MonoBehaviour
{
    public GameObject GameManager;
    public Image SelectedImage;
    private GameObject Sunit;

    void Update()
    {
        Sunit = GameManager.GetComponent<GameManager>().unit;
        if (Sunit != null)
            SelectedImage.sprite = Sunit.GetComponent<SpriteRenderer>().sprite;
    }
}
