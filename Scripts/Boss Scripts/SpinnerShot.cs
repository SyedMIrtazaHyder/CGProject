using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SpinnerShot : StateMachineBehaviour
{
    public GameObject obj;
    public int obstacleNo = 6;
    float timer;
    public float width = 0.5f;
    float snipTime = 3f;
    public float agroDis = 10f;
    NavMeshAgent agent;
    Transform player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        for (int i = 0; i < obstacleNo; i++)
        {
            agent = animator.GetComponent<NavMeshAgent>();
            Debug.Log("Attacking");
            player = GameObject.FindGameObjectWithTag("Player").transform;
            spawnObj(animator.transform.position); //spawning 15 random objects
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position); //makes path to player location if player closeby
        float distance = Vector3.Distance(player.position, animator.transform.position);
        timer += Time.deltaTime;
        if (timer > snipTime)
        {
            if (distance < agroDis)
                animator.SetBool("isDamaged", true);
            animator.SetBool("isFar", false);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

    void spawnObj(Vector3 position)
    {
        float xPos = UnityEngine.Random.Range(-width, width);
        // Smoothly tilts a transform towards a target rotation.
        float tiltAroundY = UnityEngine.Random.Range(-180f, 180f); //setting a range for the rotation of obstacle around x axis.

        //float tiltAroundX = Input.GetAxis("Vertical") * Random.Range(-180f, 180f);

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, tiltAroundY, 0); //Euler rotation allows us to shift angle using degrees

        // Dampen towards the target rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * Random.Range(0, 180.0f));

        Instantiate(obj, new Vector3(xPos, position.y, position.z), target);
    }
}
