/*!
 * 
 * \brief Custom Player Input Manager Implementation
 * \author Vicente Brisa Saez
 * \version 0.1
 * \date 2023
 * \copyright GPL v3 License
 * 
 */
using UnityEngine;
using UnityEngine.InputSystem;

namespace Vicen_te.InputSystem
{
    public class PlayerInputManager : MonoBehaviour
    {
        private Rigidbody playerRigidbody;
        // Unity Events: private PlayerInput playerInput;
        private IA_PlayerControls playerInputActions;

        /// <summary>
        /// Movement Speed
        /// </summary>
        [SerializeField] private float speed = 10f;

        [SerializeField, Range(0.0f, 1.0f)] private float movementSmoothingSpeed = 0.25f;

        private Vector3 movementVector = Vector3.zero;
        private Vector2 inputVector = Vector2.zero;

        #region Smoothing 

        private Vector2 currentMovementInput = Vector2.zero;
        private Vector2 smoothInputVelocity = Vector2.zero;

		#endregion

		private void Awake()
        {
            TryGetComponent(out playerRigidbody);

            // Unity Events: playerInput = GetComponent<PlayerInput>();

            playerInputActions = new IA_PlayerControls();

            playerInputActions.AM_Grounded.Enable();
        }

        private void OnEnable()
        {
			// Unity Events: playerInput.onActionTriggered += MovementStart;
			playerInputActions.AM_Grounded.Enable();
        }

		private void OnDisable()
        {
			// Unity Events: playerInput.onActionTriggered -= MovementStart;
			playerInputActions.AM_Grounded.Disable();
        }

        private void Update()
        {
            inputVector = playerInputActions.AM_Grounded.MoveAction.ReadValue<Vector2>();
            SmoothInput(inputVector);
            movementVector = new Vector3(currentMovementInput.x, 0.0f, currentMovementInput.y);
        }

        private void FixedUpdate()
        {
			MovementPerformed();
        }

		private void MovementPerformed()
        {
		    playerRigidbody.velocity = movementVector * speed * Time.fixedDeltaTime;
		}

        private void SmoothInput(Vector2 inputVector)
        {
			currentMovementInput = Vector2.SmoothDamp(currentMovementInput, inputVector, ref smoothInputVelocity, movementSmoothingSpeed);
		}
	}
}