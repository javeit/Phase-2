namespace RedTeam
{
	using UnityEngine;

	[RequireComponent(typeof(SteamVR_TrackedObject))]
    public class AccelDecel_R : MonoBehaviour
    {
        private void Start()
		{

//            //Setup controller event listeners
//			GetComponent<SteamVR_TrackedObject>(). .TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
//			GetComponent<SteamVR_TrackedObject>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);

        }

        public GameObject vehicle;
        public float accel = 10;
        public float decel = 5;
        public float speed = 0;

//        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
//        {
//            speed += accel * Time.fixedDeltaTime;
//            Debug.Log("L pressed");
//
//        }
//
//        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
//        {
//            speed -= accel * Time.fixedDeltaTime;
//            Debug.Log("L released");
//
//        }

        void FixedUpdate()
        {
            vehicle.transform.Translate(0, 0, speed);
        }
    }
}