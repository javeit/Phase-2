namespace VRTK.Examples
{
    using UnityEngine;

    public class AccelDecel_R : MonoBehaviour
    {
        private void Start()
        {

            if (GetComponent<VRTK_ControllerEvents>() == null)
            {
                VRTK_Logger.Error(VRTK_Logger.GetCommonMessage(VRTK_Logger.CommonMessageKeys.REQUIRED_COMPONENT_MISSING_FROM_GAMEOBJECT, "VRTK_ControllerEvents_ListenerExample", "VRTK_ControllerEvents", "the same"));
                return;
            }

            //Setup controller event listeners
            GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
            GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);

        }

        public GameObject vehicle;
        public float accel = 10;
        public float decel = 5;
        public float speed = 0;

        private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
        {
            speed += accel * Time.fixedDeltaTime;
            Debug.Log("L pressed");

        }

        private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
        {
            speed -= accel * Time.fixedDeltaTime;
            Debug.Log("L released");

        }

        void FixedUpdate()
        {
            vehicle.transform.Translate(0, 0, speed);
        }
    }
}