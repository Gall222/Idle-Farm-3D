using Leopotam.Ecs;
using Components;
using UnityEngine;
using System;
using Data;

namespace Systems
{
    public class PlayerMoveSystem : IEcsRunSystem
    {
        private SceneDataComponent _sceneData;
        private StaticData _staticData;
        EcsFilter<MovableComponent, PlayerInputComponent, AnimationComponent, PlayerComponent> playerMoveFilter;

        public void Run()
        {
            foreach (var i in playerMoveFilter)
            {
                ref MovableComponent movableComponent = ref playerMoveFilter.Get1(i);
                ref PlayerInputComponent inputComponent = ref playerMoveFilter.Get2(i);
                ref AnimationComponent animationComponent = ref playerMoveFilter.Get3(i);
                ref PlayerComponent playerComponent = ref playerMoveFilter.Get4(i);

                PlayerMove(movableComponent, inputComponent, animationComponent, playerComponent);
            }
        }

        private void PlayerMove(MovableComponent movableComponent, PlayerInputComponent inputComponent, 
            AnimationComponent animationComponent, PlayerComponent playerComponent)
        {
            movableComponent.isMoving = inputComponent.direction != Vector2.zero;
            animationComponent.animator.SetBool("Move", movableComponent.isMoving);

            Vector3 direction = (Vector3.forward * inputComponent.direction.y + Vector3.right * inputComponent.direction.x).normalized;
            //движение замедляется во время покоса
            inputComponent.characterController.SimpleMove( direction * (playerComponent.player.isCutting ? inputComponent.speed / 3 : inputComponent.speed));

            if (direction != Vector3.zero)
            {
                movableComponent.transform.forward = direction;
            }
            if (movableComponent.isMoving)
            {
                PlayStepSFX(playerComponent);
            }
        }
        private void PlayStepSFX(PlayerComponent playerComponent)
        {
            playerComponent.audioSource.clip = _staticData.soundsData.step;
            if (!playerComponent.audioSource.isPlaying)
            {
                playerComponent.audioSource.Play();
            }

        }
       
    }
}