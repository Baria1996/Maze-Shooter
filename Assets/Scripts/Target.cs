using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public float health = 30f;
    public const string DEATH = "Anim_Death";
    Animation anim;
    Wandering wander;

    void Start()
    {
        anim = GetComponent<Animation>();
        wander = GetComponent<Wandering>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount; 
        if (health <= 0f)
        {
            wander.SetAlive(false);
            DeathAni();
            StartCoroutine(Die());
            
        }
    }
    
    private IEnumerator Die()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    
    public void DeathAni()
    {
        anim.CrossFade(DEATH);
    }
}
