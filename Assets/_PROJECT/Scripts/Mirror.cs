using System;
using UnityEngine;

namespace Heim
{
    public class Mirror : MonoBehaviour
    {
        [SerializeField] private Transform _playerTarget;
        [SerializeField] private Transform _playerMirror;

        private void Update()
        {
            // Calculate relative to the player target in the z axis
            var relativePosition = _playerTarget.position - transform.position;
            relativePosition.z = -relativePosition.z; // Mirror the z axis
            _playerMirror.position = transform.position + relativePosition;
            
            // Mirror rotation around the y axis
            var euler = _playerTarget.rotation.eulerAngles;
            euler.y = -euler.y;
            _playerMirror.rotation = Quaternion.Euler(euler);
        }
    }
}
