using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {
    GameObject player;

	// Use this for initialization
	void Start () {
        player = PlayerManager.instance.player;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<Health>().TakeDamage();
    }
}
