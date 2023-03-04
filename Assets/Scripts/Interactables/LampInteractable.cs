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
    public class LampInteractable : PickableInteractable
    {
		public override void Interact(Transform instigator)
		{
			base.Interact(instigator);

			// Funcionalidad extra al interactuar
		}
	}
}