using UnityEngine;

namespace CameraControllers
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float cameraFollowSpeed;
        private Transform _cameraTransform;
        private Transform _playerTransform;
        private Vector3 _distanceByPlayer;

        private void Start()
        {
            _cameraTransform = GetComponent<Transform>();
            _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            _distanceByPlayer = CalculateDistance(_playerTransform);
        }

        private void FixedUpdate()
        {
            CameraFollow();
        }

        private void CameraFollow()
        {
            if (!_playerTransform)
            {
                return;
            }

            var playerPosition = _playerTransform.position;
            var cameraDistance = playerPosition + _distanceByPlayer;
            _cameraTransform.position = Vector3.Lerp(_cameraTransform.position, cameraDistance,
                cameraFollowSpeed * Time.deltaTime);
            _cameraTransform.LookAt(playerPosition);
        }

        private Vector3 CalculateDistance(Transform targetTransform)
        {
            return _cameraTransform.position - targetTransform.position;
        }
    }
}