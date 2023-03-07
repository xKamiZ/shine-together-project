/*!
 * 
 * \brief Controlador de las animaciones del personaje del jugador.
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
    public class PlayerAnimationHandler : MonoBehaviour
    {
        private Animator animator;

		#region Animator Hash Values

		private int horizontalHash, lampHash;

		#endregion

		private void Awake()
		{
			TryGetComponent(out animator);
		}
		private void Start()
		{
			horizontalHash = Animator.StringToHash("Horizontal");
            //lampHash = Animator.StringToHash("Lamp");
        }

		public void UpdateAnimator(float movementX, int lamp)
		{
			animator.SetFloat(horizontalHash, movementX, 0.1f, Time.deltaTime);
            //animator.SetFloat(lampHash, lamp, 0.1f, Time.deltaTime);
        }
	}
}