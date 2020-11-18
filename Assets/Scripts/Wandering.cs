using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : MonoBehaviour {

    public float speed = 3f;
    public float obstacleRange = 1f;

    bool _alive = true;

    // Use this for initialization
    void Start()
    {
        _alive = true;
    }

    // Update is called once per frame
    void Update () {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                PlayerCharacter player = hitObject.GetComponent<PlayerCharacter>();

                if (player != null)
                {
                    Debug.Log("hit");
                }                

                if (hit.distance < obstacleRange)
                {
                    transform.Rotate(0, 180, 0);
                }                
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    public bool GetAlive()
    {
        return _alive;
    }
}
