using UnityEngine;
using UnityEngine.UI;

public class GetHP : MonoBehaviour
{
    public GameObject GameManager;
    public Text healthText;
    private GameObject Sunit;
    void Update()
    {
        Sunit = GameManager.GetComponent<GameManager>().unit;
        if (Sunit != null)
        healthText.text = "HEALTH: " + Sunit.GetComponent<UnitParameters>().CurrentHealthPoints + " / " + Sunit.GetComponent<UnitParameters>().MaxHealthPoints;
    }
}
