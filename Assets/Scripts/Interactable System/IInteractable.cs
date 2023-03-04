/*!
 * 
 * \brief Defines an Interactable object
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
    public interface IInteractable
    {
        /// <summary>
        /// Si true, se llama a Interact() directamente cuando
        /// se entre en trigger con el objeto.
        /// </summary>
        bool InteractionOnTrigger { get; }
        void Interact(IInteractionInstigator instigator);
        bool HasBeenInteracted { get; }
    }
}