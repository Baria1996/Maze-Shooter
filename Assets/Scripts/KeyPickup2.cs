using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickup2 : MonoBehaviour {
    public GameObject gate1, gate2;

    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Managers.Inventory.AddItem("key");
            Destroy(gameObject);
            Destroy(gate1);
            Destroy(gate2);
        }
    }
}
