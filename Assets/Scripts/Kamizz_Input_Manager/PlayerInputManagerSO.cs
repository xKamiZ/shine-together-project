/*
 * 
 * AUTHOR: Fran Caamaño Martínez
 * Custom Player Input Manager Implementation
 * 
 */

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Kamizz.UnityGameUtils
{
	/// <summary>
	/// Input Manager - Gestiona los inputs del jugador y dispara eventos correspondientes a cada uno
	/// </summary>
	[CreateAssetMenu(fileName = "New Player Input Manager", menuName = "Utils/Player Input Manager")]
	public class PlayerInputManagerSO : ScriptableObject, IA_PlayerControls.IAM_GroundedActions
	{
		// C# Script de los player controls
		private IA_PlayerControls _playerControls;

		#region Input Events

		// Usando Unity Events - Librería UnityEngine.Events
		//public event UnityAction OnJump;
		//public event UnityAction<Vector2> OnMove;

		// Usando Actions de C# -> System
		public event Action<Vector2> OnMoveInputPerformed = delegate { };
		public event Action OnMoveInputCanceled = delegate { };

		#endregion

		#region Built-In Methods

		private void OnEnable()
		{
			if (_playerControls == null)
			{
				_playerControls = new IA_PlayerControls();

				// Descomentar cuando estén implementadas las interfaces de los action maps
				// Sustituir ActionMapName por el nombre del action map correspondiente en el asset

				_playerControls.AM_Grounded.SetCallbacks(this);
			}

			// Habilita por primera vez el input
			EnableGameplayInput();
		}
		private void OnDisable()
		{
			DisableAllGameplayInput();
		}

		#endregion Built-In Methods

		#region Enable / Disable Input

		/// <summary>
		/// Habilita todos los action maps
		/// </summary>
		public void EnableGameplayInput()
		{
			_playerControls.Enable();
		}

		/// <summary>
		/// Deshabilita todos los action maps
		/// </summary>
		public void DisableAllGameplayInput()
		{
			_playerControls.Disable();
		}

		#endregion Enable / Disable Input

		#region Input Calls

		/// <summary>
		/// Se llama cuando las teclas de movimiento han sido accionadas
		/// </summary>
		public void OnMoveAction(InputAction.CallbackContext context)
		{
			if (context.phase == InputActionPhase.Performed) OnMoveInputPerformed?.Invoke(context.ReadValue<Vector2>());
			if (context.phase == InputActionPhase.Canceled) OnMoveInputCanceled?.Invoke();
		}

		#endregion Input Calls
	}
}