using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//inspired by https://www.youtube.com/watch?v=dq0k9vvuxpi

//This script is used to make the people walk around the scene. It uses the NavMeshAgent to move the people around the scene.
public class WalkingPeopleScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public GameObject PATH;
    private Transform[] PathPoints;

    public float minDistance;

    public int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        //get the NavMeshAgent and the Animator components
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        PathPoints = new Transform[PATH.transform.childCount];
        for (int i = 0; i < PathPoints.Length; i++)
        {
            PathPoints[i] = PATH.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        roam();
    }
    void roam()
    {
        //if the distance between the person and the next point is less than the minDistance, then the person will move to the next point
        if (Vector3.Distance(transform.position, PathPoints[index].position) < minDistance)
        {
            if (index >= 0 && index < PathPoints.Length - 1)
            {
                index += 1;
            }
            else
            {
                index = 0;
            }
        }

        //move the person to the next point
        agent.SetDestination(PathPoints[index].position);
        animator.SetFloat("vertical", !agent.isStopped ? 1 : 0);
    }

}
