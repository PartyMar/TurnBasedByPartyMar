using System.Collections;
using System.Collections.Generic;
using System.Linq; 
using UnityEngine;


public class MachinaDeusStuff : MonoBehaviour
{
    //Enemy or Computer
    //public GameObject Player = null;
    private List<GameObject> FriendlyUnits = new List<GameObject>();
    private List<GameObject> AiUnits = new List<GameObject>();
    void Start()
    {
        AiUnits = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        FriendlyUnits = GameObject.FindGameObjectsWithTag("Player").ToList();
    }

    // Update is called once per frame
    void Update(){
        //Turn();
    }

    //private void Turn(){
    //    //Player Has Selected a Unit, and Given a order to move
    //    //Then Ai select a unit, and give movent order
        
    //    //if(Player.GetComponent<PlayerControl>().GetUnit() != null && Player.GetComponent<PlayerControl>().GetGotoGridPosition() != null && Player.GetComponent<PlayerControl>().GetGotoGridPosition() != Player.GetComponent<PlayerControl>().GetUnit().transform.position)
    //    //{
    //    //    //Move Player Unit
    //    //    Vector3 PlayerStart = Player.GetComponent<PlayerControl>().GetUnit().transform.position;
    //    //    if (Player.GetComponent<PlayerControl>().GetGotoGridPosition().x - PlayerStart.x <= 1 && Player.GetComponent<PlayerControl>().GetGotoGridPosition().y - PlayerStart.y <= 1 && Player.GetComponent<PlayerControl>().GetUnit().GetComponent<UnitParameters>().CurrentActionPoints != 0)
    //    //    {
    //    //        //Move 1 Point
    //    //        Player.GetComponent<PlayerControl>().GetUnit().transform.position = Player.GetComponent<PlayerControl>().GetGotoGridPosition() + new Vector3(0.5f, 0.5f, -1f); 
    //    //    }

    //        //var nr = Random.Range(0, AiUnits.Count);

    //        //var ChosenFoe = AiUnits[nr];
    //        //var FoePos = ChosenFoe.gameObject.transform.position;
    //        //Vector3 FoeAttackPos = new Vector3(0f,0f,0f);
           
    //        //for (int i = 0; i < FriendlyUnits.Count; i++)
    //        //{
    //        //    if(i == 0){
    //        //    FoeAttackPos = FriendlyUnits[i].gameObject.transform.position;
    //        //    }

    //        //    else if(Vector3.Distance(FoePos , FriendlyUnits[i].gameObject.transform.position) < Vector3.Distance(FoeAttackPos , FoePos) ){
                    
    //        //        FoeAttackPos = FriendlyUnits[i].gameObject.transform.position;

    //        //    }
    //        //}
    //        ////Move To AttackPos;
    //        //ChosenFoe.transform.position = Vector3.Normalize(FoeAttackPos);           
    //    }

    //}
}
