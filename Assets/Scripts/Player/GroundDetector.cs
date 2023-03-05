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
    [DisallowMultipleComponent]
    public class GroundDetector : MonoBehaviour
    {
		[SerializeField] private Transform rayOrigin = default;
        [SerializeField] private LayerMask groundLayer = default;
        [SerializeField] private float maxRayLenght = 1.5f;

		public bool Grounded { get; private set; } = false;


		private void Update()
		{
			if (Physics.Raycast(rayOrigin.position, Vector3.down, out RaycastHit hit, maxRayLenght, groundLayer))
				Grounded = true;
			else
				Grounded = false;
		}

#if UNITY_EDITOR

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawRay(rayOrigin.position, Vector3.down);
		}

#endif
	}
}