using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class StrikeState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    public int agroDis;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        Debug.Log("Attacking");
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position); //makes path to player location if player closeby
        float distance = Vector3.Distance(player.position, animator.transform.position);
        //Debug.Log(agent.transform.position.ToString() + "\nand Animator at: " + animator.transform.position.ToString());
        if (distance > agroDis )
        {
            animator.SetBool("isDamaged", false);
            animator.SetBool("isAttack", false);
            animator.SetBool("isFar", true);
        }

        
        //animator.transform.position = player.position;
        //agent.SetDestination(animator.transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position); //when player away use long range attacks
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
