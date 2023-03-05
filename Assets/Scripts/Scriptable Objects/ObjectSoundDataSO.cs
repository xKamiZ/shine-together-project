/*!
 * 
 * \brief Player Controller Implementation
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
    [CreateAssetMenu(fileName = "New Sound Data", menuName = "Data/Object Sound Data")]
    public class ObjectSoundDataSO : ScriptableObject
    {
        [field: SerializeField] public AudioClip PickUpSFX { get; private set; }
        [field: SerializeField] public AudioClip DropSFX { get; private set; }
    }
}