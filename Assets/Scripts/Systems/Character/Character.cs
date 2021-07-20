using UnityEngine;

namespace Systems.Character
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField] private Animator Animator;

        public void SetCharacterVelocity(Vector3 velocity)
        {
            Animator.SetFloat("Velocity", velocity.magnitude);
        }

        public void BeginEvent(CharacterEvent characterEvent)
        {
             characterEvent.BeginEvent(this);
        }
    }
}