﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBehaviour : StateMachineBehaviour {
    private int rand;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rand = Random.Range(0, 3);

        if (rand == 0)
            animator.SetTrigger("atk1");
        else if (rand == 1)
            animator.SetTrigger("atk3");
        else
            animator.SetTrigger("run");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}