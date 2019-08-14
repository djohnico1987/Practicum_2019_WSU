using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    public EnemyParameters enemyVariables;
    public Rigidbody rb;
    private Transform target;
    
    void Start()
    {
        if (enemyVariables == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " in script enemyVariables for public variables");
            gameObject.GetComponent<enemyBullet>().enabled = false;
        }
        if (rb == null)
        {
            Debug.Log("Check game object - " + gameObject.name + " needs a rigidbody.");
            gameObject.GetComponent<enemyBullet>().enabled = false;
        }
        target = playerManager.instance.player.transform;
    }

    private void OnEnable()
    {
        StartCoroutine(Lifetime());
    }

    void Update()
    {
        FacePlayer();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * enemyVariables.bulletSpeed;
        
    }

    void FacePlayer()
    {
        //makes enemy face player
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * enemyVariables.bulletTurnSpeed);
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(enemyVariables.bulletLifetime);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy") && !other.CompareTag("EnemyDamage"))
        {
            gameObject.SetActive(false);
        }
    }
}
