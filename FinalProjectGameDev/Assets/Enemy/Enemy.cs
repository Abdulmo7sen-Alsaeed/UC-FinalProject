using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject target;
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    int counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        if (counter == 0 )
        {
            agent.SetDestination(point1.transform.position);
            counter=1;
        }
        if(counter>5)
            agent.SetDestination(target.transform.position);



    }
    private void OnCollisionEnter(Collision other)
    
    {
        //counter = 4;
        if ( other.gameObject.tag == "player")
        {
            agent.SetDestination(target.transform.position);
            counter = 10;
            Vector3 currentPosition=new Vector3(transform.position.x,transform.position.y,transform.position.z);
            transform.position = currentPosition;
        }



        if ( other.gameObject.tag == "point1" && counter<5)
        {
            Debug.Log("hi");
            agent.SetDestination(point2.transform.position);
            
        }
        if ( other.gameObject.tag == "point2" && counter < 5)
        {
            agent.SetDestination(point3.transform.position);

        }
        if ( other.gameObject.tag == "point3" && counter < 5)
        {
            agent.SetDestination(point1.transform.position);

        }
    }

    // i have used simple logic for the enemy as it moves between three points until the player collides
    // then it will follow the player
}