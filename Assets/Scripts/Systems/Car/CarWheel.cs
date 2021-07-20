using UnityEngine;

namespace Systems.Car
{
    public class CarWheel : MonoBehaviour
    {
        [SerializeField] private float baseSpeed;
        [SerializeField] private bool isSteer;
        [SerializeField] private float steerAngle = 50;
        [SerializeField] private Transform wheelMesh;
        [SerializeField] private Transform wheelTurnTransform;
        private Rigidbody _bodyRigidbody;
        
        public float Acceleration { get; set; }
        public float Steer { get; set; }

        private void Awake()
        {
            _bodyRigidbody = transform.root.GetComponent<Rigidbody>();
        }

        public void FixedUpdateWheels()
        {
            Debug.DrawRay(transform.position, -transform.up, Color.magenta);
            
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hit, 10, 1 >> LayerMask.NameToLayer("Default")))
            {
                _bodyRigidbody.AddForceAtPosition(transform.forward * Acceleration * baseSpeed, hit.point);

                if (isSteer)
                {
                    transform.localRotation = Quaternion.Euler(0, steerAngle * Steer, 0);
                    wheelTurnTransform.localRotation = transform.localRotation;
                }

                Vector3 locVel = transform.InverseTransformDirection(_bodyRigidbody.GetPointVelocity(hit.point));
            
                _bodyRigidbody.AddForceAtPosition(locVel.x * -transform.right, hit.point, ForceMode.Acceleration);

                wheelMesh.transform.position = transform.position;
                wheelMesh.Rotate(Vector3.right * _bodyRigidbody.GetPointVelocity(hit.point).magnitude);
            }
        }

    }
}
