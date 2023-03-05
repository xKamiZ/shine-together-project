using System;
using UnityEngine;

namespace NightmaresProject
{
    public class StepSimulator : MonoBehaviour
    {
        [SerializeField] private float _distanceToStep = 2.5f;

        private Vector3 _lastPosition;
        public event Action OnStepPerformed;

        private void Start() => _lastPosition = transform.position;

		private void Update()
        {
            Vector2 d = new Vector2(transform.position.x - _lastPosition.x, transform.position.z - _lastPosition.z);

            if (d.magnitude > _distanceToStep)
            {
				_lastPosition = transform.position;
                OnStepPerformed?.Invoke();
			}
		}
	}
}