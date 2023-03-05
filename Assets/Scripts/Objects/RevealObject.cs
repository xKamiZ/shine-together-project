using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace ShineTogether
{
    public class RevealObject : MonoBehaviour
    {
        public List<RevealPoint> revealPoints;
        [SerializeField] private float radius = 0.25f;
        [SerializeField] private int nodesRevealed = 0;
        public bool active;
        [SerializeField] private MeshRenderer revealObjectMaterial;
        [SerializeField, Range(0f, 255)] private float revealObjectOpacity = 0;
        private MeshCollider meshCollider;

        [Header("Colors")]
        [SerializeField] private TypeOfColor typeOfColor;
        [SerializeField] private Lamp redLamp;
        [SerializeField] private Lamp blueLamp;

        public float Radius => radius;

        // Start is called before the first frame update
        private void Start()
        {
            Refresh();
            meshCollider = GetComponent<MeshCollider>();
        }

        public void Refresh()
        {
            foreach (RevealPoint revealPoint in revealPoints)
            {
                revealPoint.gameObject.GetComponent<SphereCollider>().radius = radius;
                revealPoint.typeOfColor = typeOfColor;
                revealPoint.radius = radius;
                revealPoint.redLamp = redLamp;
                revealPoint.blueLamp = blueLamp;
            }
            revealObjectMaterial.sharedMaterial.color = 
                new Color(revealObjectMaterial.material.color.r , revealObjectMaterial.material.color.g , revealObjectMaterial.material.color.b, revealObjectOpacity / 255f);
        }

        private void AddNode()
        {
            nodesRevealed++;
        }

        private void CheckNodes()
        {
            float aplha = (float)nodesRevealed / (float)revealPoints.Count;
            revealObjectMaterial.sharedMaterial.color = 
                new Color(revealObjectMaterial.material.color.r, revealObjectMaterial.material.color.g, revealObjectMaterial.material.color.b, aplha);
        }

        void CheckPosition()
        {
            foreach (RevealPoint revealPoint in revealPoints) 
            {
                if (revealPoint.active)
                    AddNode();
            }
            //Debug.Log(nodesRevealed);
            CheckNodes();
            active = nodesRevealed >= revealPoints.Count;
            nodesRevealed = 0;
        }

        void CheckCollider()
        {
            meshCollider.enabled = active;
        }

        // Update is called once per frame
        void Update()
        {
            CheckPosition();
            CheckCollider();
        }
    }
}
