using Systems.Cameras;
using UnityEngine;
using Systems.Car;

namespace Systems.Character
{
    public class CarExitEvent : CharacterEvent
    {
        private BaseCar car;

        public CarExitEvent(BaseCar car)
        {
            this.car = car;
        }
        
        public override void BeginEvent(Character character)
        {
            character.gameObject.SetActive(true);
            CameraManager.SelectCamera<DefaultPlayerCamera>();
            character.transform.position = car.transform.position + (car.transform.right.normalized * 2);
            car.TurnOff();
        }
    }
}