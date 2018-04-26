using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarEngine))]
public class SimpleCarController : MonoBehaviour {

	CarEngine engine;

	void Update () {
		float acceleration = Input.GetAxis ("Vertical");
		float turnAngle = Input.GetAxis ("Horizontal");

		//Debug.Log ("Acceleration Input: " + acceleration);

		if (acceleration > 0)
			engine.Accelerate (acceleration * engine.maxAcceleration);
		else if (acceleration < 0)
			engine.Decelerate (Mathf.Abs(acceleration) * engine.maxDeceleration);

		engine.TurnAngle = turnAngle * engine.maxTurnAngle;
	}

	void Start() {
		engine = GetComponent<CarEngine> ();
	}
}
