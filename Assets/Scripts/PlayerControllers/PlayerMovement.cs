using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerControllers
{
    public class PlayerMovement : MonoBehaviour
    {
        private Rigidbody _playerRb;
        public Transform playerTransform;
        [SerializeField] private float movementSpeed;

        private void Awake()
        {
            _playerRb = GetComponent<Rigidbody>();
            //playerTransform = GetComponent<Transform>();
        }

        private void FixedUpdate()
        {
            ObjectMovement();
        }
        

        private void ObjectMovement()
        {
            float xAxis = Input.GetAxis("Horizontal");
            float zAxis = Input.GetAxis("Vertical");
            float elapsedTime = Time.fixedDeltaTime;
            float smoothMovement = movementSpeed * elapsedTime;
            Vector3 move = new Vector3(xAxis * smoothMovement, 0, zAxis * smoothMovement);
            _playerRb.AddForce(move,ForceMode.VelocityChange);
        }
    }
}