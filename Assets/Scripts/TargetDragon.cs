using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetDragon : MonoBehaviour {
    public float health = 100;
    public int damage;
    private float timeBtwDamage = 1.5f;
    public Slider healthBar;
    public Animator anim;
    public AudioSource growl;
    private bool _fightStarted = false;
    public GameManager gm;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        growl = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //anim.SetBool("animate", false);
        healthBar.value = health;
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        //Debug.Log("Damage: "+amount+" health: "+health);
        if (health <= 0f)
        {
            anim.SetTrigger("death");
            StartCoroutine(gm.OpenMenu());
        }
    }



    public void StartFight()
    {
        anim.SetBool("animate", true);
        growl.Play();
        _fightStarted = true;
    }
}
