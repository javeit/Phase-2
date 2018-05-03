using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CarEngine : MonoBehaviour {

	public float acceleration;
	public float deceleration;
	public float maxSpeed;
	public float maxReverseSpeed;
	public float maxTurnAngle;

	public float minTurnSpeed;

	float speed;
	float direction;

	Rigidbody rb;

	public void Accelerate(float amount) {
		amount = Mathf.Clamp(amount, -1f, 1f);

		if(speed == 0f && amount < 0f) {
			Reverse(amount);
		} else {

			if(amount > 0f)
				speed += amount * acceleration * Time.fixedDeltaTime;
			else
				speed += amount * deceleration * Time.fixedDeltaTime;
		
			speed = Mathf.Clamp(speed, -1 * maxSpeed, maxSpeed);
		}
	}

	public void Reverse(float amount) {
		amount = Mathf.Clamp(amount, -1f, 0f);
		speed += amount * acceleration;
		speed = Mathf.Clamp(speed, -1 * maxReverseSpeed, 0f);
	}

	public void SetDirection(float direction) {
		if(Mathf.Abs(speed) >= minTurnSpeed)
			this.direction = Mathf.Clamp(direction, -1f, 1f);
	}

	void FixedUpdate() {
		transform.Rotate (transform.up, direction * maxTurnAngle * Time.deltaTime);
		rb.velocity = transform.forward.normalized * speed;
	}

	void Start() {
		rb = GetComponent<Rigidbody>();
		speed = 0f;
	}
}
