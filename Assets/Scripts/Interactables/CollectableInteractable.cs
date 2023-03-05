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
	[RequireComponent(typeof(AudioSource))]
	public class CollectableInteractable : MonoBehaviour, IInteractable
	{
		[Header("Data")]
		[SerializeField] private ObjectSoundDataSO objectSounds;

		private AudioSource soundSource = default;

		private void Awake()
		{
			TryGetComponent(out soundSource);
		}

		[field: SerializeField] public bool InteractionOnTrigger { get; private set; }
        public bool HasBeenInteracted { get; private set; }
        public void Interact(IInteractionInstigator instigator)
		{
			soundSource.PlayOneShot(objectSounds.PickUpSFX);
            HasBeenInteracted = true;

			gameObject.SetActive(false);
		}
		private void OnEnable()
        {
            HasBeenInteracted = false;
        }
    }
}