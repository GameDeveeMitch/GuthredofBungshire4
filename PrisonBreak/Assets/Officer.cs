using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Officer : MonoBehaviour
{
    public string officeName = "Dick Mcgee";
    public float relationshipLikeStatus = 50f;
    public GameObject target;
    public Vector3 patrolPos;
    private NavMeshAgent nav;
    private bool haveTarget = false;
    // Start is called before the first frame update
    void Start()
    {
        nav = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!haveTarget)
        {
            nav.destination = patrolPos;
        }
        else
        {
            Debug.Log("running");
            nav.destination = target.transform.position;
        }
    }
    public void GetThePrisoner()//for right now I will not pass anything in but eventually they should be able to attack other prisoners
    {
        target = GameObject.FindGameObjectWithTag("Player");
        haveTarget = true;

    }
    public void CalledOff()
    {
        haveTarget = false;
        nav.destination = patrolPos;
    }
}
