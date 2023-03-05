/*!
 * 
 * \brief Player Controller Implementation
 * \author Fran Caamaño Martínez
 * \version 0.1
 * \date 2023
 * \copyright GPL v3 License
 * \note Vicente Brisa Saez can manipulate the document during the Jame gam 15
 * 
 */

using UnityEngine;
using Kamizz.UnityGameUtils;

namespace ShineTogether
{
    public class PlayerController : MonoBehaviour, IInteractionInstigator
	{
		[Header("DATA")]
        [SerializeField] private PlayerInputManagerSO playerInput;
		[SerializeField] private FootstepSoundDataSO footstepSounds;

		[SerializeField] private float movementSpeed = 10f;
		[SerializeField] private float rotationSpeed = 2.0f;
		[SerializeField, Range(0.0f, 0.5f)] private float movementSmoothingSpeed = 0.25f;

		private PlayerAnimationHandler animHandler;
		private AudioSource footstepSource;
		private GroundDetector groundDetector;
		private InteractionController interactionController;
		private Rigidbody playerRigidbody;
		private Vector3 movementVector = Vector3.zero;
		private Vector2 movementInputVector = Vector2.zero;

        private PickableInteractable equippedInteractable;

		public bool IsMoving  => movementInputVector.x != 0.0f || movementInputVector.y != 0.0f;

        #region Smoothing 

        private Vector2 currentMovementInput = Vector2.zero;
		private Vector2 smoothInputVelocity = Vector2.zero;

		#endregion Smoothing

		#region Built In Methods

		private void Awake()
		{
			TryGetComponent(out animHandler);
			TryGetComponent(out footstepSource);
			TryGetComponent(out  groundDetector);
			TryGetComponent(out playerRigidbody);
			TryGetComponent(out interactionController);
		}
		private void OnEnable()
		{
			playerInput.OnMoveInputPerformed += MovementInputPerformed;
			playerInput.OnInteractPerformed += InteractionInputPerformed;
		}
		private void OnDisable()
		{
			playerInput.OnMoveInputPerformed -= MovementInputPerformed;
			playerInput.OnInteractPerformed -= InteractionInputPerformed;
		}
		private void Update()
		{
			SmoothInput(movementInputVector);

			movementVector = new Vector3(currentMovementInput.x, 0.0f, currentMovementInput.y);

			animHandler.UpdateAnimator(movementVector.magnitude);
		}
		private void FixedUpdate()
		{
			playerRigidbody.velocity = movementVector * movementSpeed * Time.fixedDeltaTime;

			HandleRotation();
		}

		#endregion Built In Methods

		private void MovementInputPerformed(Vector2 inputValue) => movementInputVector = inputValue;
		private void SmoothInput(Vector2 inputVector)
		{
			currentMovementInput = Vector2.SmoothDamp(currentMovementInput, inputVector, ref smoothInputVelocity, movementSmoothingSpeed);
		}
		private void InteractionInputPerformed()
		{
			if (equippedInteractable)
			{
				equippedInteractable.Drop();
                equippedInteractable = null;
            }
			else
				interactionController.TryInteraction();
        }
		public void OnStepPerformed()
		{
			if (groundDetector.Grounded)
				footstepSource.PlayOneShot(footstepSounds.GetRandomFootstep());
		}
		private void HandleRotation()
		{
			if (IsMoving)
			{
				Quaternion targetRotation = Quaternion.LookRotation(movementVector, Vector3.up);

				transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
			}
		}

		public void SetInteractedObject(IInteractable interactable)
		{
			equippedInteractable = (PickableInteractable)interactable;
        }
    }
}