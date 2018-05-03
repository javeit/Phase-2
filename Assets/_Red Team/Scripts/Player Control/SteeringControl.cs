using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CarEngine))]
public class SteeringControl : MonoBehaviour {

    CarEngine engine;
    public GameObject wheel;
    public float wheelAngle = 0;
    public float direction;

    void Start()
    {
        engine = GetComponent<CarEngine>();
    }

    void FixedUpdate()
    {
        //get wheel angle
        wheelAngle = wheel.transform.eulerAngles.x;

        //set direction to appropriate value
        if (wheelAngle <= 180 && wheelAngle >= 60)
        {
            direction = -1;
        }
        else if (wheelAngle >= 180 && wheelAngle <= 300)
        {
            direction = 1;
        }
        else if (wheelAngle >= 5 && wheelAngle< 60)
        {
            direction = - wheelAngle / 60;
        }
        else if (wheelAngle <= 355 && wheelAngle > 300)
        {
            direction =  1 - (( (wheelAngle - 300) / 60) % 5 );
        }
        else
        {
            direction = 0;
        }
      
        //tell engine how to turn
		engine.SetDirection(direction);
	}
}
