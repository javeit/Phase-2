using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarEngine))]
public class SimpleCarController : MonoBehaviour {

	CarEngine engine;

	void FixedUpdate () {

        float acceleration = Input.GetAxis ("Vertical");
		//direction = Input.GetAxis ("Horizontal");

		engine.Accelerate(acceleration);
		//engine.SetDirection(direction);
	}

	void Start() {
		engine = GetComponent<CarEngine>();
	}
}
