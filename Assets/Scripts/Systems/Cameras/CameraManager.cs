using UnityEngine;

namespace Systems.Cameras
{
    public class CameraManager : MonoBehaviour
    {
        private static BaseCamera[] allCameras;

        private void Awake()
        {
            allCameras = FindObjectsOfType<BaseCamera>();
            SelectCamera<DefaultPlayerCamera>();
        }
        
        public static void SelectCamera <T> () where T : BaseCamera
        {
            foreach (BaseCamera allCamera in allCameras)
            {
                allCamera.Toggle(allCamera.GetType() == typeof(T));
            }
        }
    }
}