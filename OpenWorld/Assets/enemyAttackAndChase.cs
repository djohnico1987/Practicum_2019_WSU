using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAttackAndChase : MonoBehaviour
{
    public EnemyParameters enemyVariables;
    private Transform target;
    private NavMeshAgent agent;
    private bool isChasing = false;
    private Vector3 startp, startr;

    void Start()
    {
        //error check for public variable
        if(enemyVariables == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script enemyAttackAndChase for public variables");
            gameObject.GetComponent<enemyAttackAndChase>().enabled = false;
        }

        //gets player transform from game manager
        target = playerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        //used for npc to return to starting position
        startp = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        //how ai chases player
        //if player runs out of chasing range, disengages and returns to original start
        if (distance >= enemyVariables.losesPlayer && isChasing == true)
        {
            isChasing = false;
            agent.SetDestination(startp);
            //resets stopping distance so that it goes to original starting spot
            agent.stoppingDistance = 0f;
        }
        //keeps chasing and attacking the player when in range
        else if (isChasing == true)
        {
            agent.SetDestination(target.position);
            if(distance <= agent.stoppingDistance)
            {
                //keeps the enemy facing player
                FaceTarget();
            }
        }
        //chases player to move within attack range
        else if (distance <= enemyVariables.detectPlayer && isChasing == false)
        {
            agent.SetDestination(target.position);
            //enemy stops to attack at range
            agent.stoppingDistance = enemyVariables.attackRange/2f;
            isChasing = true;
        }
    }

    void FaceTarget()
    {
        //makes enemy face player
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        //draws range for level design
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, enemyVariables.detectPlayer);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, enemyVariables.losesPlayer);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, enemyVariables.attackRange);
    }
}
