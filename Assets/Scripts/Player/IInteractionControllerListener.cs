/*!
 * 
 * \brief Listener de los eventos que env�a el InteractionController
 * \author Fran Caama�o Mart�nez
 * \version 0.1
 * \date 2023
 * \copyright GPL v3 License
 * \note Vicente Brisa Saez can manipulate the document during the Jame gam 15
 * 
 */

namespace ShineTogether
{
    public interface IInteractionControllerListener
    {
        void OnInteractionPerformed();
    }
}