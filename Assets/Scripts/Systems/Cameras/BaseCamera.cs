using UnityEngine;

namespace Systems.Cameras
{
    public class BaseCamera : MonoBehaviour
    {
        public virtual void Toggle(bool isOn)
        {
            gameObject.SetActive(isOn);
        }
    }
}