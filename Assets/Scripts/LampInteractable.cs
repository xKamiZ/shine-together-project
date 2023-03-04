/*!
 * 
 * \brief Objeto interactivo luz de minero
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
    public class LampInteractable : MonoBehaviour, IInteractable
    {
		public bool HasBeenInteracted { get; set; } = false;

		public void Interact()
		{
			Debug.Log($"Interaction with {gameObject.name}");
			HasBeenInteracted = true;
		}
    }
}