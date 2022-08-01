using Leopotam.Ecs;
using Components;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;
using Mouse = UnityEngine.InputSystem.Mouse;

namespace Systems
{
    public class PlayerInputSystem : IEcsRunSystem, IEcsInitSystem, IEcsDestroySystem
    {
        private SceneDataComponent _sceneData;
        private PlayerInput _playerInput = new PlayerInput();
        EcsFilter<PlayerInputComponent, PlayerComponent> inputEventsFilter = null;
        private Vector2 pointA;
        private Vector2 pointB;

        public void Init()
        {
            _playerInput.Enable();
        }
        public void Run()
        {
            GetTouchVectors();
            AddDirection();
            PlayerCutting();
        }

        private void PlayerCutting()
        {
            if (_sceneData.startCutting)
            {
                _sceneData.startCutting = false;

                foreach (var i in inputEventsFilter)
                {
                    ref PlayerComponent playerComponent = ref inputEventsFilter.Get2(i);
                    if (!playerComponent.player.isCutting)
                    {
                        playerComponent.player.isCutting = true;
                        ref var entity = ref inputEventsFilter.GetEntity(i);
                        ref PlayerHarvestingComponent playerHarvestingComponent = ref entity.Get<PlayerHarvestingComponent>();
                    }
                }
            }
        }

        private void GetTouchVectors()
        {

            var isTouching = _playerInput.Touch.isTouched.ReadValue<float>();
            var mousePos = _playerInput.Touch.Position.ReadValue<Vector2>();
            var startPos = _playerInput.Touch.Start.ReadValue<Vector2>();
            if (isTouching > 0)
            {
                pointA = startPos;
                pointB = mousePos;
                _sceneData.joystickBack.transform.position = startPos;
                _sceneData.joystickBack.gameObject.SetActive(true);
                _sceneData.joystickInner.gameObject.SetActive(true);
            }
            else
            {
                pointA = Vector2.zero;
                pointB = Vector2.zero;
                _sceneData.joystickBack.gameObject.SetActive(false);
                _sceneData.joystickInner.gameObject.SetActive(false);
            }
        }
        private void AddDirection()
        {
            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1);
            MoveInnerJoystick(direction);
            foreach (var i in inputEventsFilter)
            {
                ref PlayerInputComponent inputComponent = ref inputEventsFilter.Get1(i);
                ref PlayerComponent playerComponent = ref inputEventsFilter.Get2(i);
                inputComponent.direction =  direction;
            }
        }
        private void MoveInnerJoystick(Vector2 direction)
        {
            _sceneData.joystickInner.transform.position = (Vector2)_sceneData.joystickBack.transform.position +
                (direction * _sceneData.innerJoystickOffset );
        }

        public void Destroy()
        {
            _playerInput.Disable();
        }
    }
}