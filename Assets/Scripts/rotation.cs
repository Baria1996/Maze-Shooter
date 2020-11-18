using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rotation : MonoBehaviour {
    [SerializeField]
    private Vector3 rot;
    // Use this for initialization
    void Start () {
        rot = new Vector3(0, 2, 0);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(rot);
	}
}
