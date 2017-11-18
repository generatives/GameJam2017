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

        var vector = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
            vector += -transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
            vector += transform.right;
        }

        var direction = new Vector3(transform.forward.x, 0, transform.forward.z);
        
        if (Input.GetKey(KeyCode.W))
        {
            //Move the Rigidbody to the right constantly at speed you define (the red arrow axis in Scene view)
            vector += direction;
        }

        if (Input.GetKey(KeyCode.S))
        {
            //Move the Rigidbody to the left constantly at the speed you define (the red arrow axis in Scene view)
            vector += -direction;
        }
        vector *= Speed;

        if(vector != Vector3.zero)
        {
            _body.AddForce(vector, ForceMode.VelocityChange);
        }
        else
        {
            _body.velocity = Vector3.zero;
        }
    }
}
