
using UnityEngine;

namespace ShineTogether
{
    [CreateAssetMenu(fileName = "New Footstep Sounds", menuName = "Data/Footsteps")]
    public class FootstepSoundDataSO : ScriptableObject
    {
        [field: SerializeField] public AudioClip[] FootstepSounds {  get; private set; }

        public AudioClip GetRandomFootstep()
        {
            int randomClipIndex = Random.Range(0, FootstepSounds.Length);

            return FootstepSounds[randomClipIndex];
        }
    }
}