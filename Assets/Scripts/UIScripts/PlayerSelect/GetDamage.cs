using UnityEngine;
using UnityEngine.UI;

public class GetDamage : MonoBehaviour
{
    public GameObject GameManager;
    public Text DamageText;
    private GameObject Sunit;
    void Update()
    {
        Sunit = GameManager.GetComponent<GameManager>().unit;
        if (Sunit != null)
            DamageText.text = "DAMAGE: " + Sunit.GetComponent<UnitParameters>().DamagePoints;
    }
}