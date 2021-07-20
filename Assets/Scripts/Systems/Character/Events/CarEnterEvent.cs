using Systems.Cameras;
using UnityEngine;
using Systems.Car;

namespace Systems.Character
{
    public class CarEnterEvent : CharacterEvent
    {
        private BaseCar car;

        public CarEnterEvent(BaseCar car)
        {
            this.car = car;
        }
        
        public override void BeginEvent(Character character)
        {
            character.gameObject.SetActive(false);
            CameraManager.SelectCamera<DefaultCarCamera>();
            car.TurnOn();
        }
    }
}