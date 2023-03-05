using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShineTogether
{
    [RequireComponent(typeof(AudioSource))]
    public class LevelInteractable : MonoBehaviour, IInteractable
    {
        [Header("NextLevel")]
        [SerializeField] private GameObject transition;
        [SerializeField] private string nextlevel;

        [Header("Data")]
        [SerializeField] private ObjectSoundDataSO objectSounds;
        private AudioSource soundSource = default;

        [field: SerializeField] public bool InteractionOnTrigger { get; private set; }
        public bool HasBeenInteracted { get; private set; }

        // Start is called before the first frame update
        void Awake()
        {
            TryGetComponent(out soundSource);
        }
        public void Interact(IInteractionInstigator instigator)
        {
            transition.SendMessage("LoadLevel", nextlevel);
            soundSource.PlayOneShot(objectSounds.PickUpSFX);
            HasBeenInteracted = true;

            GetComponent<Collider>().enabled = false;
        }

        private void OnEnable()
        {
            HasBeenInteracted = false;
        }
    }
}
