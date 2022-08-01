using UnityEngine;

namespace Components
{
    public struct PlayerInputComponent
    {
        public PlayerInput playerInput;
        public float speed;
        public Vector2 direction;
        public Rigidbody playerRigidbody;
        public CharacterController characterController;
    }
}