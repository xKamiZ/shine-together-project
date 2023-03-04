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
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerInputManagerSO playerInput;
		[SerializeField] private float movementSpeed = 10f;
		[SerializeField, Range(0.0f, 1.0f)] private float movementSmoothingSpeed = 0.25f;

		private InteractionController interactionController;
		private Rigidbody playerRigidbody;
		private Vector3 movementVector = Vector3.zero;
		private Vector2 movementInputVector = Vector2.zero;

		#region Smoothing 

		private Vector2 currentMovementInput = Vector2.zero;
		private Vector2 smoothInputVelocity = Vector2.zero;

		#endregion

		#region Built In Methods

		private void Awake()
		{
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
		}
		private void FixedUpdate()
		{
			playerRigidbody.velocity = movementVector * movementSpeed * Time.fixedDeltaTime;
		}

		#endregion

		private void MovementInputPerformed(Vector2 inputValue) => movementInputVector = inputValue;
		private void SmoothInput(Vector2 inputVector)
		{
			currentMovementInput = Vector2.SmoothDamp(currentMovementInput, inputVector, ref smoothInputVelocity, movementSmoothingSpeed);
		}
		private void InteractionInputPerformed() => interactionController.TryInteraction();
	}
}