using UnityEngine;
using UnityEngine.UI;

public class EGetDamage : MonoBehaviour
{
    public GameObject GameManager;
    public Text DamageText;
    private GameObject Sunit;
    void Update()
    {
        Sunit = GameManager.GetComponent<GameManager>().enemyunit;
        if (Sunit != null)
            DamageText.text = "DAMAGE: " + Sunit.GetComponent<UnitParameters>().DamagePoints;
    }
}
