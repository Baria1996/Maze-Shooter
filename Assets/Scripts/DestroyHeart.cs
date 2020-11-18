using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyHeart : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Managers.Inventory.AddItem("health");
            Destroy(gameObject);
        }
    }
}
