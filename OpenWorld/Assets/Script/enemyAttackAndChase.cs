using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAttackAndChase : MonoBehaviour
{
    public EnemyParameters enemyVariables;
    public Transform firePoint;
    private Transform target;
    private NavMeshAgent agent;
    private bool isChasing = false, isFiring = false, isInSight = false, checkSight = false;
    private Vector3 startp, startr;

    void Start()
    {
        //error check for public variable
        if (enemyVariables == null || firePoint == null)
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
            if(isFiring == false && distance <= enemyVariables.attackRange)
            {
                isFiring = true;
                StartCoroutine(Shoot());
            }
            if(distance <= agent.stoppingDistance)
            {
                //keeps the enemy facing player
                FaceTarget();
            }
        }
        //chases player to move within attack range
        else if (distance <= enemyVariables.detectPlayer && isChasing == false)
        {
            if (!checkSight)
            {
                isInSight = LineOfSightCheck();
                checkSight = true;
            }

            if (isInSight)
            {
                agent.SetDestination(target.position);
                //enemy stops to attack at range
                agent.stoppingDistance = enemyVariables.attackRange / 2f;
                isChasing = true;
            }
        }
    }

    IEnumerator Shoot()
    {
        objectPooler.instance.SpawnFromPool("EnemyBullet", firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(enemyVariables.timeBetweenShots);
        isFiring = false;
    }
    
    bool LineOfSightCheck()
    {
        RaycastHit hit;
        Physics.Raycast(firePoint.position, (target.position - firePoint.position), out hit, enemyVariables.detectPlayer, enemyVariables.seesThrough);
        Debug.DrawRay(firePoint.position, (target.position - firePoint.position), Color.red);
        if(hit.collider.gameObject.tag == "Player")
        {
            checkSight = false;
            return true;
        }
        checkSight = false;
        return false;
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
    }
}
