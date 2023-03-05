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
        Lamp lamp;

        private void Start()
        {
            lamp = GetComponent<Lamp>();
        }

        public override void Interact(IInteractionInstigator instigator)
		{
			base.Interact(instigator);
            lamp.SetCirclePosition
               (new Vector3(lamp.CirlceTransform.transform.position.x, 0.501f, lamp.CirlceTransform.transform.position.z));
            // Funcionalidad extra al interactuar
        }
        public override void Drop()
        {
            lamp.SetDefaultCirclePosition();
        }
    }
}