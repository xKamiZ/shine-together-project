using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShineTogether
{
    public class RevealObject : MonoBehaviour
    {
        [SerializeField] private Transform player;
        public List<RevealPoint> revealPoints;
        [SerializeField] private float radius = 0.25f;
        [SerializeField] private int nodesRevealed = 0;
        public bool active;
        public float Radius => radius;

        // Start is called before the first frame update
        private void Start()
        {
            Refresh();
        }

        public void Refresh()
        {
            foreach (RevealPoint revealPoint in revealPoints)
            {
                revealPoint.gameObject.GetComponent<SphereCollider>().radius = radius;
            }
        }

        private void AddNode()
        {
            nodesRevealed++;
        }

        void CheckPosition()
        {
            foreach (RevealPoint revealPoint in revealPoints) 
            {
                if (revealPoint.active)
                    AddNode();
            }
            Debug.Log(nodesRevealed);
            active = nodesRevealed >= 3;
            nodesRevealed = 0;
        }

        // Update is called once per frame
        void Update()
        {
            CheckPosition();
        }
    }
}
