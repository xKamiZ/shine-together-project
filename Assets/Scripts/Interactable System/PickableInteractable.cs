/*!
 * 
 * \brief Clase base para un IInteractable que el jugador puede recoger.
 * \author Fran Caamaño Martínez
 * \version 0.1
 * \date 2023
 * \copyright GPL v3 License
 * \note Vicente Brisa Saez can manipulate the document during the Jame gam 15
 * 
 */

using UnityEngine;

namespace ShineTogether
{
	public abstract class PickableInteractable : MonoBehaviour, IInteractable
	{
		[field: SerializeField] public bool InteractionOnTrigger { get; private set; }

		[Header("Pickable Interactable Settings")]
		[SerializeField, Tooltip("Posición dónde se va a enganchar el objeto cuando se equipe")] private Transform targetPositionTransform;
		[SerializeField] private Transform dropPositionTransform;

		public virtual void Interact(IInteractionInstigator instigator)
		{
			transform.SetParent(targetPositionTransform, false);
			transform.position = targetPositionTransform.position;
			transform.rotation = Quaternion.identity;

			instigator.SetInteractedObject(this);
		}

		public void Drop()
		{
			// TO DO: Poner el objeto en el suelo.
			transform.SetParent(null, false);
			transform.position = dropPositionTransform.position;
			transform.rotation = Quaternion.identity;
		}
	}
}