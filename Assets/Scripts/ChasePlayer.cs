using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//navmesh agent is used to allow an object to move in the scene
//[RequireComponent(typeof(AudioSource))]
public class ChasePlayer : MonoBehaviour {
    //enemy will attack in a certain range defined by lookradius
    public float lookRadius = 7f;
    //set a target to follow
    Transform target;
    //use AI for this
    NavMeshAgent agent;
    public const string ATTACK = "Anim_Attack";
    Animation anim;
    Wandering alive;
    AudioSource audioData;

    void Start () {
        //its better to use this method (using instance) instead of 
        //searching through all the objects within the scene.

        //playermanager script always keeps track of the player's instance.
        //it is applied to gamemanager to keep track of
        //player as soon as the game starts.
        //(convert type of 'instance' from gameobject to transform)
        target = PlayerManager.instance.player.transform; 
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animation>();
        alive = GetComponent<Wandering>();
        audioData = GetComponent<AudioSource>();
    }
    
    void Update() {
        //returns distance between target and players position
        float distance = Vector3.Distance(target.position, transform.position); 
        //if player is within the lookradius and enemy is still alive
        if (distance <= lookRadius && alive.GetAlive())
        {
            //set destination is a func of navmesh which calculates a new path
            //here the new destination is the position of the player/target
            agent.SetDestination(target.position);
            //the enemy will stop chasing the target if the stopping distance is reached
            //this is where we want enemy to attack plater/target
            if (distance <= agent.stoppingDistance)
            {
                //play animation while attacking.
                //this animation also calls the EnemyAttack function 
                //which is not actually called in any script but instead
                //called through this attack animation
                AttackAni();
                //making enemy face towards the target
                FaceTarget();
            }
        }
	}

    void FaceTarget()
    {
        //get the direction vector.
        //normalized returns this vector with the magnitude of 1
        Vector3 direction = (target.position - transform.position).normalized;
        //now get the rotation towards the target
        //using quaternions which represent rotations
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        //now update our own rotation to
        //point in this direction
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    public void AttackAni()
    {
        //crossfade gives the effect of fading the previous animation
        //and introducing a new one (the one given as parameter)
        anim.CrossFade(ATTACK);
    }

    //this func is called by the attack animation
    public void EnemyAttack()
    {
        //references the health component of player/target
        //and calls the takedamage function
        target.GetComponent<Health>().TakeDamage();
    }

    //Gizmos are used to help in visual debugging in the cene view
    //here a wirefeame sphere is drawn around the enemy
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        //the position and radius of the gizmo is given to draw the sphere
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
