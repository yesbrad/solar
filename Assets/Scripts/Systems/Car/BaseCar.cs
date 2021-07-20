using System;
using Systems.Character;
using Systems.Interaction;
using UnityEngine;

namespace Systems.Car
{
    public class BaseCar : MonoBehaviour, IInteractable
    {
        [SerializeField] private Vector3 centreOfMass;

        private CarWheel[] carWheels;
        private Rigidbody _rg;

        private Character.Character _currentCharacter;
        
        public bool IsOn { get; private set; }

        private void Awake()
        {
            _rg = GetComponent<Rigidbody>();
            _currentCharacter = FindObjectOfType<PlayerController>();
            carWheels = GetComponentsInChildren<CarWheel>();
            TurnOff();
        }

        private void FixedUpdate()
        {
            _rg.centerOfMass = centreOfMass;
            UpdateWheels();
        }

        private void UpdateWheels()
        {
            if (!IsOn) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentCharacter.BeginEvent(new CarExitEvent(this));
            }
            
            foreach (CarWheel wheel in carWheels)
            {
                wheel.Acceleration = Input.GetAxis("Vertical");
                wheel.Steer = Input.GetAxis("Horizontal");
                wheel.FixedUpdateWheels();
            }
        }

        public IInteractable OnInteract()
        {
            Debug.Log("Interact ewithn car");
            FindObjectOfType<PlayerController>().BeginEvent(new CarEnterEvent(this));
            return this;
        }

        public void TurnOn()
        {
            IsOn = true;
        }
        
        public void TurnOff()
        {
            IsOn = false;
        }
        
    }
}
