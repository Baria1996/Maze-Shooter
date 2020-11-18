using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss : MonoBehaviour {
    public int health; 
    public int damage;
    private float timeBtwDamage = 1.5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timeBtwDamage > 0)
        {
            //timeBtwDamage -= time
        }
	}
}
