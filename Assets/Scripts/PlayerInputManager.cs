/*!
 * 
 * \brief Custom Player Input Manager Implementation
 * \author Vicente Brisa Saez
 * \version 0.1
 * \date 2023
 * \copyright GPL v3 License
 * \note Fran Caamaño Martínez can manipulate the document during the Jame gam 15
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

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            // Unity Events: playerInput = GetComponent<PlayerInput>();

            playerInputActions = new IA_PlayerControls();
            playerInputActions.AM_Grounded.MoveAction.started += MovementStart;
            playerInputActions.AM_Grounded.MoveAction.canceled += MovementCancel;
            // Unity Events: playerInput.onActionTriggered += MovementStart;

            playerInputActions.AM_Grounded.Enable();
        }

        private void OnEnable()
        {
            playerInputActions.AM_Grounded.Enable();
        }
        private void OnDisable()
        {
            playerInputActions.AM_Grounded.Disable();
        }

        private void Update()
        {
            MovementPerformed();
        }

        private void MovementPerformed()
        {
            Vector2 inputVector = playerInputActions.AM_Grounded.MoveAction.ReadValue<Vector2>();
            Debug.Log(inputVector);
            playerRigidbody.velocity = new Vector3(inputVector.x, 0, inputVector.y) * speed;
        }

        /// <summary>
        /// Smooth the start movement
        /// </summary>
        /// <param name="context"></param>
        private void MovementStart(InputAction.CallbackContext context)
        {
            // \todo On movement start
            // Idea: Interpolate 0 to X playerRigidbody.velocity
        }

        /// <summary>
        /// Smooth the cancel movement
        /// </summary>
        /// <param name="context"></param>
        private void MovementCancel(InputAction.CallbackContext context)
        {
            // \todo On movement Cancel
            // Idea: Interpolate 0 to X playerRigidbody.velocity
        }
    }
}