using UnityEngine;
using UnityEngine.AI;

public class IdleState : StateMachineBehaviour
{
    NavMeshAgent agent;
    float timer;
    Transform player;
    public float agroDistance = 20f;
    public GameObject boss;
    public float snipTime = 5f;
    //public HealthBar health;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        timer = 0;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*if (health.getHealth() == 0)
            animator.SetBool("isDead", true);*/
        
        timer += Time.deltaTime;
        //Invoke("destination", 0.5f);//makes path to player location if player closeby
        float distance = Vector3.Distance(player.position, animator.transform.position);
        agent.SetDestination(player.position);
        //Debug.Log(distance);
        if (distance < agroDistance)
        {
            animator.SetBool("isDamaged", true);
        }
        if (timer > snipTime)
        {
            animator.SetBool("isFar", true);
        }
        //random walk animation here
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

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
}
