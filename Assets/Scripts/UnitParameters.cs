using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class UnitParameters : MonoBehaviour
{
    [SerializeField] public int CurrentActionPoints;
    [SerializeField] public int MaxActionPoints;
    [SerializeField] public int CurrentHealthPoints;
    [SerializeField] public int MaxHealthPoints;
    [SerializeField] public int DamagePoints;

    public Button EndOfTurn;


    void Start()
    {
    }

    void Update()
    {
        EndOfTurn.onClick.AddListener(ResetActionPoints);
        if (this.CurrentHealthPoints < 1)
        {
            SoundManager.PlaySound("Death");
            //
            Destroy(gameObject);
        }
  
    }
    private void ResetActionPoints()
    {
        CurrentActionPoints = MaxActionPoints;
    }


}
