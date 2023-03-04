/*!
 * 
 * \brief Controlador de las interacciones del jugador con IInteractables
 * \author Fran Caamaño Martínez
 * \version 0.1
 * \date 2023
 * \copyright GPL v3 License
 * \note Vicente Brisa Saez can manipulate the document during the Jame gam 15
 * 
 */

using System;
using UnityEngine;

namespace ShineTogether
{
    public class InteractionController : MonoBehaviour
    {
		private IInteractable scopeInteractable = null;

		/// <summary>
		/// Objetos a los que se notificará sobre eventos de interacción.
		/// Ej: Gestor de interfaces para mostrar el popup...
		/// </summary>
		private IInteractionControllerListener[] listeners;

		private IInteractionInstigator instigator;

		private void Awake()
		{
			TryGetComponent(out instigator);
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent(out IInteractable interactable))
			{
				if (interactable.InteractionOnTrigger) interactable.Interact(instigator);
				else scopeInteractable = interactable;
			}
				
		}
		private void OnTriggerExit(Collider other)
		{
			if (other.TryGetComponent(out IInteractable interactable))
				scopeInteractable = null;
		}

		/// <summary>
		/// Intenta una interacción con el objeto en el foco.
		/// </summary>
		public void TryInteraction()
		{
			if (scopeInteractable != null)
			{
				scopeInteractable.Interact(instigator);
				NotifyListeners();
			}
		}

		private void NotifyListeners()
		{
			if (listeners == null) return;

			Array.ForEach(listeners, x => x.OnInteractionPerformed());
		}
	}
}