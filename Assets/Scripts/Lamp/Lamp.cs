using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Shapes;

namespace ShineTogether
{
    public class Lamp : MonoBehaviour
    {
        [Header("Light Settings")]
        [SerializeField] private Light pointLight;
        [SerializeField] private MeshRenderer lampMaterial;
        [SerializeField] private Color lampColor;
        private Color lampGlassColor;
        [SerializeField, Range(0f, 255)] private float glassOpacity = 78;

        [Header("Sphere Radius")]
        [SerializeField] private float radius = 1.5f;
        [SerializeField] private SphereCollider sphereCollider;

        public Color LampColor => lampColor;
        public float Radius => radius;
        public Transform CirlceTransform => cirlceTransform;
      

        [Header("Light Radius")]
        [SerializeField] private Transform cirlceTransform;
        [SerializeField] public Color FillColor;
        [SerializeField] private bool Border;
        public Color BorderColor;
        [Range(0f, 0.8f)]
        public float BorderWidth = 0.2f;
        private Vector3 Center;

        void Start()
        {
            Refresh();
        }

        public void Refresh()
        {
            lampColor.a = 255f;
            pointLight.color = lampColor;
            pointLight.range = radius;

            lampGlassColor = lampColor;
            lampGlassColor.a = glassOpacity / 255f;
            lampMaterial.sharedMaterial.color = lampGlassColor;

            sphereCollider.radius = radius;
        }

        public void DrawCircle()
        {
            CircleInfo circleInfo = new CircleInfo
            {
                center = cirlceTransform.position,
                forward = cirlceTransform.forward,
                radius = radius,
                fillColor = FillColor
            };

            if (Border)
            {
                circleInfo.bordered = true;
                circleInfo.borderColor = BorderColor;
                circleInfo.borderWidth = BorderWidth;
            }

            Circle.Draw(circleInfo);
        }

        void Update()
        {
            DrawCircle();
        }
    }
}

