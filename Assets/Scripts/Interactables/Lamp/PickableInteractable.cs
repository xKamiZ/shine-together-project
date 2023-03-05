/*!
 * 
 * \brief Clase base para un IInteractable que el jugador puede recoger.
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
	[RequireComponent(typeof(AudioSource))]
	public abstract class PickableInteractable : MonoBehaviour, IInteractable
	{
		[field: SerializeField] public bool InteractionOnTrigger { get; private set; }

		[Header("Data")]
		[SerializeField] protected ObjectSoundDataSO objectSounds;

		[Header("Pickable Interactable Settings")]
		[SerializeField, Tooltip("Posición dónde se va a enganchar el objeto cuando se equipe")] private Transform targetPositionTransform;
		[SerializeField] protected Transform dropPositionTransform;

		public bool HasBeenInteracted { get; private set; }

		private AudioSource soundSource = default;

		protected virtual void Awake()
		{
			TryGetComponent(out soundSource);
		}

        public virtual void Interact(IInteractionInstigator instigator)
		{
			transform.SetParent(targetPositionTransform, false);
			transform.position = targetPositionTransform.position;
			transform.rotation = Quaternion.identity;
			instigator.SetInteractedObject(this);
			HasBeenInteracted = true;

			soundSource.PlayOneShot(objectSounds.PickUpSFX);
		}

		public virtual void Drop()
		{
			transform.SetParent(null, false);
			transform.position = dropPositionTransform.position;
			transform.rotation = Quaternion.identity;
            HasBeenInteracted = false;

			soundSource.PlayOneShot(objectSounds.DropSFX);
		}
	}
}