using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunBehaviour : StateMachineBehaviour {

    public float timer;
    public float minTime;
    public float maxTime;
    public float speed;
    private Transform playerPos;


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos =PlayerManager.instance.player.transform;
        timer = Random.Range(minTime, maxTime);
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (timer <= 0)
            animator.SetTrigger("atk1");
        else
            timer -= Time.deltaTime;

        Vector3 target = new Vector3(playerPos.position.x, playerPos.position.y, playerPos.position.z);
        animator.transform.position = Vector3.MoveTowards(animator.transform.position, target, speed * Time.deltaTime);

        //get the direction vector.
        //normalized returns this vector with the magnitude of 1
        Vector3 direction = (playerPos.position - animator.transform.position).normalized;
        //now get the rotation towards the target
        //using quaternions which represent rotations
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //now update our own rotation to
        //point in this direction
        animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
