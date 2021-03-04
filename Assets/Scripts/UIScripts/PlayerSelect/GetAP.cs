
using UnityEngine;
using UnityEngine.UI;

public class GetAP : MonoBehaviour
{
    public GameObject GameManager;
    public Text APText;
    private GameObject Sunit;
    void Update()
    {
        Sunit = GameManager.GetComponent<GameManager>().unit;
        if (Sunit != null)
            APText.text = "ACTION POINTS: " + Sunit.GetComponent<UnitParameters>().CurrentActionPoints + " / " + Sunit.GetComponent<UnitParameters>().MaxActionPoints;
    }
}
