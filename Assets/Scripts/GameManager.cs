using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public Tilemap map;
    public GameObject unit = null;
    public GameObject enemyunit = null;

    private GameObject AIselectedunit = null;
    private GameObject AIselectedFunit = null;

    private Vector3Int GetGridPosition;
    private Vector3 GotoGridPosition;


    private List<GameObject> FriendlyUnits = new List<GameObject>();
    private List<GameObject> AiUnits = new List<GameObject>();
    public GameObject NextLvlButtom;

    void Start()
    {
        // Lists of Player units and Enemy units for AI
        AiUnits = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        FriendlyUnits = GameObject.FindGameObjectsWithTag("Player").ToList();

        NextLvlButtom.SetActive(false);
    }


    void Update()
    {
        AISelect();
        if (Input.GetMouseButtonDown(0))
        {
            //Before add the enemy turns I put all calculations here

            //Chose Foe

            //Foe need calcute best move

            //Excute Move

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GetGridPosition = map.WorldToCell(mousePosition);
            GotoGridPosition = map.GetCellCenterWorld(GetGridPosition);

            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.tag == "Enemy")
            {
                enemyunit = hit.collider.gameObject;
                if (unit != null)
                {
                    var distanceAbs = CalculateDistance(enemyunit.transform.position, unit);
                    if (distanceAbs.x <= 1 && distanceAbs.y <= 1 && unit.GetComponent<UnitParameters>().CurrentActionPoints != 0)
                    {
                        AttackFoeScript(enemyunit, unit);
                        AISelect();
                        EnemyAct();
                    }
                }
            }
            else
            {
                if (hit.collider != null && hit.collider.tag == "Player")
                {
                    if (unit == null)
                    {
                        unit = hit.collider.gameObject;
                        Debug.Log("Selected " + unit.name);
                    }
                    else if (unit == hit.collider.gameObject)
                    {
                        unit = null;
                        Debug.Log("Unit unselected");
                    }
                    else if (unit != hit.collider.gameObject && hit.collider.tag == "Player")
                    {
                        unit = hit.collider.gameObject;
                        Debug.Log("Selected " + unit.name);
                    }

                }
                OnMouseDown();
            }
           
        }
        if (AiUnits.Count == 0 && FriendlyUnits.Count != 0)
        {
            SoundManager.PlaySound("Victory");
            enabled = false;
            NextLvlButtom.SetActive(true);
        }
        if (FriendlyUnits.Count == 0 && AiUnits.Count != 0)
        {
            SoundManager.PlaySound("Lose");
            enabled = false;
        }
    }

    //Method to move a PlayerUnit
    public void OnMouseDown()
    {

        if (unit != null )
        {
            
            TileBase clickedTile = map.GetTile(GetGridPosition);
            Vector2 DistanceToMove = CalculateDistance(GotoGridPosition, unit);

            //NEW checking if unit have a ActionPoints and if it "Walkable tile"
            if (unit != null && GotoGridPosition != unit.transform.position && unit.GetComponent<UnitParameters>().CurrentActionPoints != 0 &&
                DistanceToMove.x <= 1 && DistanceToMove.y <= 1 && clickedTile.name == "WastelandTile")
            {

                //Move Player Unit to 1 point
                unit.transform.position = GotoGridPosition;
                unit.GetComponent<UnitParameters>().CurrentActionPoints -= 1;
                SoundManager.PlaySound("PlayerStep");
                Debug.Log("CLicked TIle is " + clickedTile.name);

                EnemyAct();
            }
        }
    }

    // EnemyChose unit to act
    public void AISelect()
    {
        //Clear
        AIselectedunit = null;
        AIselectedFunit = null;
        float currentMinDistance = 1000;
        foreach (GameObject Funit in FriendlyUnits)
        {
            foreach (GameObject Eunit in AiUnits)
            {
                if (Vector2.Distance(Funit.transform.position, Eunit.transform.position) < currentMinDistance && Eunit.GetComponent<UnitParameters>().CurrentActionPoints>0)
                {
                    currentMinDistance = Vector2.Distance(Funit.transform.position, Eunit.transform.position);
                    AIselectedunit = Eunit;
                    AIselectedFunit = Funit;
                }


            }
        }
    }

    //Method to move an EnemyUnit
    public void EnemyAct()
    {
        if (AIselectedFunit != null)
        {
            Vector2 distanceAbs = CalculateDistance(AIselectedFunit.transform.position, AIselectedunit);
            Vector2 distance = CalculateDistanceForEnemy(AIselectedFunit.transform.position, AIselectedunit);
            float DistanceRight = Vector2.Distance(AIselectedFunit.transform.position, AIselectedunit.transform.position);

            Debug.Log("DistanceRight is:" + DistanceRight);

            var Target = AIselectedunit.transform.position + Vector3.Normalize(distance);

            Debug.Log(" AIselectedunit is " + AIselectedunit.transform.position);
            Debug.Log(" Normalize is " + Vector3.Normalize(distance));

            Vector3Int Target3 = map.WorldToCell(Target);
            var TargetTile = map.GetTile(Target3);

            Debug.Log("TargetTIle is " + TargetTile.name);

            if (DistanceRight > 1 && AIselectedunit.GetComponent<UnitParameters>().CurrentActionPoints != 0 && map.GetCellCenterWorld(Target3) != AIselectedFunit.transform.position)
            {
                //Move Enemy Unit
                AIselectedunit.transform.position = map.GetCellCenterWorld(Target3);
                AIselectedunit.GetComponent<UnitParameters>().CurrentActionPoints--;
            }
            else if (TargetTile.name != "RuinTile" && distanceAbs.x <= 1 && distanceAbs.y <= 1 && AIselectedunit.GetComponent<UnitParameters>().CurrentHealthPoints > 0)
            {
                //Attack
                AttackFoeScript(AIselectedFunit, AIselectedunit);
            }
        }
    }




    //method to calculate distance
    public Vector2 CalculateDistance(Vector3 Goto, GameObject unitPosition)
    {
        float DistanceX = Mathf.Abs(Goto.x - unitPosition.transform.position.x);
        float DistanceY = Mathf.Abs(Goto.y - unitPosition.transform.position.y);
        return new Vector2(DistanceX, DistanceY);
    }
    
    //method to calculate distance for Foe (cuz Mathf.Abs didnt work well with Normalize method)
    public Vector2 CalculateDistanceForEnemy(Vector3 Goto, GameObject unitPosition)
    {
        float DistanceX = Goto.x - unitPosition.transform.position.x;
        float DistanceY = Goto.y - unitPosition.transform.position.y;
        return new Vector2(DistanceX, DistanceY);
    }

    // Script to attack
    private void AttackFoeScript(GameObject Defender, GameObject Attacker)
    {

        if (Attacker != null && Attacker.GetComponent<UnitParameters>().CurrentActionPoints != 0)
        {
            SoundManager.PlaySound("PlayerAttack");
            Defender.GetComponent<UnitParameters>().CurrentHealthPoints -= Attacker.GetComponent<UnitParameters>().DamagePoints;
            Attacker.GetComponent<UnitParameters>().CurrentActionPoints -= 1;
            if (Defender.GetComponent<UnitParameters>().CurrentHealthPoints < 1)
            {
                //Remove unit from list
                AiUnits.Remove(Defender);
                FriendlyUnits.Remove(Defender);
                Debug.Log("Removed Defender" + Defender.name);
            }
            else if (Defender.GetComponent<UnitParameters>().CurrentActionPoints != 0)
            {
                Attacker.GetComponent<UnitParameters>().CurrentHealthPoints -= Defender.GetComponent<UnitParameters>().DamagePoints;
                Defender.GetComponent<UnitParameters>().CurrentActionPoints -= 1;
            }
            //Check if unit any unit is dead    
            if(Attacker.GetComponent<UnitParameters>().CurrentHealthPoints < 1)
            {
            AiUnits.Remove(Attacker);
            FriendlyUnits.Remove(Attacker);
            Debug.Log("Removed Attacker" + Attacker.name);
            }
        }
    }

}

