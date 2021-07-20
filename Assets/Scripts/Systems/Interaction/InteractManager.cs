using System;
using UnityEngine;

namespace Systems.Interaction
{
    public class InteractManager : MonoBehaviour
    {
        [SerializeField] private float detectionLength = 2;

        private void Update()
        {
            if(!Input.GetKeyDown(KeyCode.Space)) return;
            
            if (Physics.Raycast(transform.position + Vector3.up, transform.forward, out RaycastHit hit, detectionLength))
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                if (interactable != null)
                {
                    interactable.OnInteract();
                }
            }
        }
    }
}