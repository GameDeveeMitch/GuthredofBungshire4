using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class SimpleOfficer : MonoBehaviour
{
    public float seeDistance = 10f;
    public bool shouldPursue = false;
    public bool checkIfTargetInSight = false;
    public bool moveToNextSpot = true;
    public float pursueTimer = 3f;
    public Transform[] patrolPoints;
    public LayerMask playerLayer;

    private Transform patrolPoint;
    private bool finding = false;
    private int curPatrol = 0;
    private NavMeshAgent nav;
    private float pursuitTimer;
    private GameObject prevTarget;
    private void Start()
    {
        moveToNextSpot = false;
        prevTarget = new GameObject();
        nav = this.GetComponent<NavMeshAgent>();
        pursuitTimer = pursueTimer;
        patrolPoint = patrolPoints[0];
        curPatrol = 0;
    }
    private void Update()
    {
        if (!shouldPursue)
        {
            RaycastHit hit;
            if (Physics.Raycast(new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), transform.TransformDirection(Vector3.forward), out hit, seeDistance, playerLayer))
            {
                //Debug.Log("casting");
                if (hit.collider.tag.Equals("Player"))
                {
                  //  Debug.Log("seen");
                    //check to see if the player can be out of the room
                    //should be done through a player manager that talks with mitchs timer script
                    EnablePursue(hit.collider.gameObject);
                }
            }
            else
            {
                if (!moveToNextSpot)
                    Patrol();
                else if(!finding)
                    StartCoroutine(FindNextSpot());

            }
        }
        else if(!checkIfTargetInSight)
        {
            Pursue();
            if(pursuitTimer > 0)
            {
                pursuitTimer -= Time.deltaTime;
                //need to check if I still see the player, if I 
            }
            else
            {
                DisablePursue();
                ResetTimer();
            }
        }
    }
    public IEnumerator FindNextSpot()
    {
        finding = true;
        int randoPatrol = Random.Range(0, patrolPoints.Length - 1);
        randoPatrol = RandoPatrolCheck(randoPatrol);
        yield return new WaitForSeconds(2f);
        patrolPoint = GetThePatrolPoint(randoPatrol);
        curPatrol = randoPatrol;
        moveToNextSpot = false;
        finding = false;
    }
    private Transform GetThePatrolPoint(int randomPatrol)
    {
        for(int i = 0; i < patrolPoints.Length; i++)
        {
            if (i.Equals(randomPatrol))
                return patrolPoints[i];
        }
        return null;
    }
    private int RandoPatrolCheck(int checkNum)
    {
        
        if (checkNum == curPatrol)//comparing the names of the patrol points
        {
            Debug.Log("got to the checking point right before the while");
            while (true)
            {
                Debug.Log(checkNum + "    " + curPatrol);
                checkNum = Random.Range(0, patrolPoints.Length - 1);
                if (((checkNum + 1) / (curPatrol + 1)) != 1)
                {
                    return checkNum;
                }
            }
        }
        else
            return checkNum;
    }
    public void Patrol()
    {
        if (Vector3.Distance(this.transform.position, patrolPoint.transform.position) > 2f)
        {
            Debug.Log("should be patrolling");
            nav.SetDestination(patrolPoint.position);
        }
        else
            moveToNextSpot = true;
    }
    private void ResetTimer()
    {
        if(pursuitTimer <= 0)
        {
            pursuitTimer = pursueTimer;
        }
    }
    public void EnablePursue(GameObject theTarget)
    {
        //Debug.Log(theTarget.name);
        AssignTarget(theTarget);
        moveToNextSpot = false;
        finding = false;
        shouldPursue = true;
        
    }
    private void DisablePursue()
    {
        finding = false;
        moveToNextSpot = true;
        shouldPursue = false;
    }
    public void Pursue()
    {
        nav.SetDestination(prevTarget.transform.position);
    }
    private void AssignTarget(GameObject target)
    {
        if (!prevTarget.Equals(target))        
             prevTarget = target;
    }
}
