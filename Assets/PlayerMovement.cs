using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {

    private Rigidbody _body;

    public float Speed;

	// Use this for initialization
	void Start () {
        _body = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetKey(KeyCode.A))
        {
            //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
            _body.velocity = transform.right * Speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
            _body.velocity = -transform.right * Speed;
        }

        var direction = new Vector3(transform.forward.x, 0, transform.forward.z);
        
        if (Input.GetKey(KeyCode.W))
        {
            //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
            _body.velocity = direction * Speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
            _body.velocity = -direction * Speed;
        }

        _body.velocity = Vector3.zero;
    }
}
