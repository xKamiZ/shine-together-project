using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ShineTogether
{
    public class Lamp : MonoBehaviour
    {
        [Header("Light Settings")]
        [SerializeField] private Light pointLight;
        [SerializeField] private MeshRenderer lampMaterial;
        [SerializeField] private Color lampColor;
        private Color lampGlassColor;
        [SerializeField] private float glassOpacity = 78;
        [SerializeField] private float lightRange = 5f;

        [Header("Sphere Radius")]
        [SerializeField] private float radius = 1.5f;
        [SerializeField] private SphereCollider sphereCollider;

        public Color LampColor => lampColor;
        public float Radius => radius;
        public float LightRadius => lightRange;


        public LineRenderer circleRender;

        void Start()
        {
            ChangeValues();
        }

        public void ChangeValues()
        {
            lampColor.a = 255f;
            pointLight.color = lampColor;
            pointLight.range = lightRange;

            lampGlassColor = lampColor;
            lampGlassColor.a = glassOpacity / 255f;
            lampMaterial.material.color = lampGlassColor;

            sphereCollider.radius = radius;
        }

        private void DrawCircle()
        {

        }

        void Update()
        {
        }
    }
}

