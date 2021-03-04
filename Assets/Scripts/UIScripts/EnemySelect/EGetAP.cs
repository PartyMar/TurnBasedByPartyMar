using UnityEngine;
using UnityEngine.UI;

public class EGetAP : MonoBehaviour
{
    public GameObject EGameManager;
    public Text EAPText;
    private GameObject ESunit;
    void Update()
    {
        ESunit = EGameManager.GetComponent<GameManager>().enemyunit;
        if (ESunit != null)
            EAPText.text = "ACTION POINTS: " + ESunit.GetComponent<UnitParameters>().CurrentActionPoints + " / " + ESunit.GetComponent<UnitParameters>().MaxActionPoints;
    }
}
