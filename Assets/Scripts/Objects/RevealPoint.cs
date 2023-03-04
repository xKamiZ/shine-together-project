using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShineTogether
{
    public class RevealPoint : MonoBehaviour
    {
        public bool active;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Lamp lamp))
            {
                active = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Lamp lamp))
            {
                active = false;
            }
        }
    }
}
