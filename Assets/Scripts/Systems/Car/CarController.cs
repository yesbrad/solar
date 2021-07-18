using System;
using UnityEngine;

namespace Systems.Car
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Vector3 centreOfMass;
        
        private Rigidbody _rg;

        private void Awake()
        {
            _rg = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            _rg.centerOfMass = centreOfMass;
        }
    }
}
