using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {
    public AudioSource aud_gem;
    public AudioSource aud_key;
    public AudioSource aud_life;
    public float moveSpeed = 5f;
    public float jumpSpeed = 7f;
    public float gravity = -9.8f;
    public float minFall = -1f;
    public float terminalVelocity = -10f;
    private float _vertSpeed;
    private ControllerColliderHit _contact;
    private CharacterController _char;
    public Health player;

    // Use this for initialization
    void Start () {
        aud_gem = GetComponent<AudioSource>();
        aud_key = GetComponent<AudioSource>();
        _char = GetComponent<CharacterController>();
        player = GetComponent<Health>();
        _vertSpeed = minFall;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero;
        bool hitGround = false;
        RaycastHit hit;

        if (_vertSpeed < 0f && Physics.Raycast(transform.position, Vector3.down, out hit))
        {
            if (hit.distance < (_char.height + _char.radius) / 1.9f)
                hitGround = true;
        }

        if (hitGround)
        {
            if (Input.GetButtonDown("Jump"))
            {
                _vertSpeed = jumpSpeed;
            }
            else
            {
                _vertSpeed = minFall;
            }
        }
        else
        {
            _vertSpeed += gravity * Time.deltaTime * 3;
            if (_vertSpeed < terminalVelocity)
                _vertSpeed = terminalVelocity;

            if (_char.isGrounded)
            {
                movement += _contact.normal;
            }
        }

        movement.y = _vertSpeed;
        movement *= moveSpeed * Time.deltaTime;
        _char.Move(movement);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        _contact = hit;
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * 4f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("gem"))
        {            
            aud_gem.Play();
        }
        else if (other.CompareTag("key"))
        {
            aud_key.Play();
        }
        else if (other.CompareTag("life"))
        {
            aud_life.Play();
        }
        if (other.CompareTag("enemy"))
        {
            player.TakeDamage();
        }
    }
}
