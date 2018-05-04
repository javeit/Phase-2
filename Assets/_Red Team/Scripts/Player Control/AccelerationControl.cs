using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

[RequireComponent(typeof(CarEngine))]
public class AccelerationControl : MonoBehaviour {

	public VRTK_ControllerEvents rightController;
	public VRTK_ControllerEvents leftController;

	CarEngine engine;

	void OnRightTriggerPressed(object sender, ControllerInteractionEventArgs e) {
		Debug.Log ("Right Pressed: Button Pressure " + e.buttonPressure);
		engine.Accelerate (e.buttonPressure);
	}

	void OnLeftTriggerPressed(object sender, ControllerInteractionEventArgs e) {
		Debug.Log ("Left Pressed: Button Pressure " + e.buttonPressure);
		engine.Accelerate (-1 * e.buttonPressure);
	}

	void Update() {
		//Debug.Log ("Right Trigger Axis: " + rightController.GetTriggerAxis ());

		engine.Accelerate (rightController.GetTriggerAxis());
		engine.Accelerate (-1 * leftController.GetTriggerAxis ());
	}

	void Start() {
		engine = GetComponent<CarEngine> ();

		rightController.TriggerHairlineStart += new ControllerInteractionEventHandler (OnRightTriggerPressed);
		leftController.TriggerHairlineStart += new ControllerInteractionEventHandler (OnLeftTriggerPressed);
	}
}
