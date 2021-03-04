using UnityEngine;
using UnityEngine.UI;

public class EGetHP : MonoBehaviour
{
    public GameObject GameManager;
    public Text healthText;
    private GameObject Sunit;
    void Update()
    {
        Sunit = GameManager.GetComponent<GameManager>().enemyunit;
        if (Sunit != null)
            healthText.text = "HEALTH: " + Sunit.GetComponent<UnitParameters>().CurrentHealthPoints + " / " + Sunit.GetComponent<UnitParameters>().MaxHealthPoints;
    }
}
