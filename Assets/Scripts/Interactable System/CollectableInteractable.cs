/*!
 * 
 * \brief Objeto interactivo colecionable
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
	public class CollectableInteractable : MonoBehaviour, IInteractable
	{
		[field: SerializeField]
		public bool InteractionOnTrigger { get; private set; }

		public void Interact(IInteractionInstigator instigator)
		{
			gameObject.SetActive(false);
		}
	}
}