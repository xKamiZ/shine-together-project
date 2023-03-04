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

namespace ShineTogether
{
    public interface IInteractable
    {
        bool HasBeenInteracted { get; }
        void Interact();
    }
}