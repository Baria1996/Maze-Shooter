using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchOperator : MonoBehaviour {

    public float radius = 3f;
    void Update() {
        if (Input.GetButtonDown("Fire3")) {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider hitCollider in hitColliders){
                hitCollider.SendMessage("Operate", SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
