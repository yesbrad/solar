using System;
using UnityEngine;

namespace Systems.Character
{
    public class PlayerController : Character
    {
        [SerializeField] private float moveSpeed = 10;
        [SerializeField] private float maxSpeed = 10;
        [Range(0,1)]
        [SerializeField] private float slowDown = 0.5f;

        [SerializeField] private float inputSmoothness = 5;
        [SerializeField] private float rotationSmoothness = 5;

        private Rigidbody rg;

        public Vector3 lookDirection;
        private Vector3 _inputs;
        private Vector3 _inputsRaw;

        private void Awake()
        {
            rg = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _inputsRaw.x = Input.GetAxisRaw("Horizontal");
            _inputsRaw.z = Input.GetAxisRaw("Vertical");

            _inputs = Vector3.Lerp(_inputs, _inputsRaw, inputSmoothness * Time.deltaTime);
            
            lookDirection = Camera.main.transform.TransformDirection(_inputs);
            lookDirection.y = 0;
            

            
            SetCharacterVelocity(rg.velocity);
        }

        private void FixedUpdate()
        {
            float input = _inputs.normalized.magnitude;
            
            if(rg.velocity.magnitude < maxSpeed)
                rg.AddForce(lookDirection * input * moveSpeed, ForceMode.Acceleration);
            
            Vector3 locVel = transform.InverseTransformDirection(rg.velocity);
            
            rg.AddForceAtPosition(locVel.x * -transform.right, transform.position, ForceMode.VelocityChange);
            
            if(input == 0)
                rg.AddForceAtPosition(-rg.velocity * slowDown, transform.position, ForceMode.VelocityChange);
            
            if (_inputs.normalized.magnitude != 0)
                rg.rotation = Quaternion.Slerp(rg.rotation, Quaternion.LookRotation(lookDirection), rotationSmoothness * Time.deltaTime);
        }
    }
}
