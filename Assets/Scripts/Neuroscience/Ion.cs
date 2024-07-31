using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
namespace Neuroscience
{
    //public class MoveIonInRandomDirection : MonoBehaviour
    public class Ion : MonoBehaviour //
    {
        private Rigidbody _rigidbody;
        private Vector3 _driftDirection;
        private bool stopped; //
        public Vector3 direction;
        public string element;
        public float speed;
        private bool _movingToPoint; //
        //[HideInInspector]
        //public IonInRangeTrigger ionInRangeTrigger;
        private void Start()
        {
            Physics.gravity = Vector3.zero;
            _rigidbody = GetComponent<Rigidbody>();
            ShootInRandomDirection();
            _movingToPoint = false; //
        }
        private void FixedUpdate()
        {
            if (_movingToPoint || stopped) return; //
            if (_rigidbody.velocity.sqrMagnitude < .01) ShootInRandomDirection();
            _rigidbody.AddForce(_driftDirection * speed, ForceMode.Force);
        }
        private Vector3 GetRandomVector3()
        {
            return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        }
        private void ShootInRandomDirection()
        {
            direction = GetRandomVector3().normalized;
            _rigidbody.AddForce(direction * speed, ForceMode.Impulse);
            _driftDirection = Vector3.Cross(direction, Vector3.up).normalized;
        }
    }
}







