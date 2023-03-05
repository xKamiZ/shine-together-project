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

namespace ShineTogether
{
    public interface IInteractionInstigator
    {
        void SetInteractedObject(IInteractable interactable);
    }
}