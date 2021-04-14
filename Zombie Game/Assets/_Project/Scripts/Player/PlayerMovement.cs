﻿namespace Zombie.Player
{
    using UnityEngine;
    using Zombie.Core;
    using System;
    public class PlayerMovement : MonoBehaviour, IEnableable
    {
        [SerializeField] private float moveSpeed, maxSpeed;

        private Rigidbody _rb;
        private float _mag = 0f;
        private bool _isEnabled = true;


        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _mag = _rb.velocity.magnitude;
            if (_mag >= maxSpeed || !_isEnabled) return;

            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            _rb.AddForce(transform.forward * z * moveSpeed * Time.deltaTime);
            _rb.AddForce(transform.right * x * moveSpeed * Time.deltaTime);
        }


        public void Enable()
        {
            _isEnabled = true;
        }

        public void Disable()
        {
            _isEnabled = false;
        }

    }
}