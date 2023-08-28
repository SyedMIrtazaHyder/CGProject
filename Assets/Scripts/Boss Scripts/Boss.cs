using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 5;
    public int maxHealth = 10;
    //private void Awake()
    //{
    //    navMeshAgent= GetComponent<NavMeshAgent>();
    //    player = GameObject.FindGameObjectWithTag("Player").transform;
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log(health);
            health--;
        }
    }

    //private void Update()
    //{
    //    navMeshAgent.destination = player.position;
    //}
}
