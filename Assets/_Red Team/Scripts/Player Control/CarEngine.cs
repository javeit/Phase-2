using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEngine : MonoBehaviour {

	/// <summary>
	/// The max acceleration.
	/// </summary>
	public float maxAcceleration;

	/// <summary>
	/// The max speed.
	/// </summary>
	public float maxSpeed;

	/// <summary>
	/// The speed of the car when it is on and the player is not doing anything
	/// </summary>
	public float idleSpeed;

	/// <summary>
	/// The rate at which the car accelerates/decelerates towards it's idle speed
	/// </summary>
	public float idleAcelleration;

	/// <summary>
	/// The max deceleration.
	/// </summary>
	public float maxDeceleration;

	/// <summary>
	/// The max turning angle.
	/// </summary>
	public float maxTurnAngle;

	/// <summary>
	/// The max stoping speed.
	/// </summary>
	public float maxStopingSpeed;

	public bool isOn;

	/// <summary>
	/// Gets or sets the turn angle while ensuring that it doesn't exceed the max value
	/// </summary>
	/// <value>The turn angle.</value>
	public float TurnAngle {
		get {
			return turnAngle;
		}
		set {
			turnAngle = Mathf.Clamp (value, -1 * maxTurnAngle, maxTurnAngle);
		}
	}

	public float speed;
	public float turnAngle;

	public void Accelerate(float acceleration) {
		// ensure acceleration does not exceed the max or result in a deccelleration
		acceleration = Mathf.Clamp (acceleration, 0, maxAcceleration);

		if (!isOn)
			return;

		speed += acceleration * Time.deltaTime;
		speed = Mathf.Clamp (speed, 0, maxSpeed);
	}

	public void Decelerate(float deceleration) {
		// ensure acceleration does not exceed the max or result in an acceleration
		deceleration = Mathf.Clamp (deceleration, 0, maxDeceleration);

		if (!isOn)
			return;

		speed -= deceleration * Time.deltaTime;
		speed = Mathf.Clamp (speed, 0, maxSpeed);
	}

	public void TurnOff() {
		if (isOn && speed <= maxStopingSpeed)
			isOn = false;
		else
			Debug.Log ("Cannot stop at this speed; Need to slow down.");
	}

	public void TurnOn() {
		isOn = true;
	}

	void Update() {

		transform.Rotate (transform.up, turnAngle * Time.deltaTime);
		transform.Translate (transform.forward * speed * Time.deltaTime);

//		if (isOn) {
//			if (speed != idleSpeed) {
//				if (Mathf.Abs (speed - idleSpeed) < idleAcelleration * Time.deltaTime) {
//					speed = idleSpeed;
//				} else if (speed > idleSpeed) {
//					Decelerate (idleAcelleration);
//				} else {
//					Accelerate (idleAcelleration);
//				}
//			}
//		} else 
		if(!isOn){
			if(speed != 0)
				Decelerate (maxDeceleration);

			if (turnAngle != 0)
				turnAngle = 0;
		}
	}

	void Start() {
		speed = 0f;
		turnAngle = 0f;
	}
}
