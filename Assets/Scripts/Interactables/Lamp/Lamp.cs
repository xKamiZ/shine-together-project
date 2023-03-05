using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Shapes;
using UnityEngine.Experimental.GlobalIllumination;

namespace ShineTogether
{
    public class Lamp : MonoBehaviour
    {
        [Header("Light Settings")]
        [SerializeField] private TypeOfColor typeOfColor;
        [SerializeField] private Light pointLight;
        [SerializeField] private MeshRenderer lampMaterial;
        [SerializeField] private Color lampColor;
        [SerializeField] private float radius = 1.5f;
        private Color lampGlassColor;
        [SerializeField, Range(0f, 255)] private float glassOpacity = 78;
        [SerializeField, Range(0f, 300)] private float intensity = 20;

        [Header("Sphere Radius")]
        [SerializeField] private float collisionRadius = 1.5f;
        [SerializeField] private SphereCollider sphereCollider;

        public Color LampColor => lampColor;
        public float Radius => radius;

        public TypeOfColor TypeOfColor;
        public Transform CirlceTransform => cirlceTransform;

      

        [Header("Light Radius")]
        [SerializeField] private Transform cirlceTransform;
        [SerializeField] public Color FillColor;
        [SerializeField] private bool Border;
        public Color BorderColor;
        [Range(0f, 0.8f)]
        public float BorderWidth = 0.2f;

        void Start()
        {
            Refresh();
        }

        public void SetCirclePosition(Vector3 position)
        {
            cirlceTransform.position = position;
            Border = false;
        }

        public void SetDefaultCirclePosition()
        {
            cirlceTransform.position = gameObject.transform.position;
            Border = true;
        }


        public void Refresh()
        {
            lampColor.a = 255f;
            pointLight.color = lampColor;
            pointLight.range = radius;
            pointLight.intensity = intensity;

            lampGlassColor = lampColor;
            lampGlassColor.a = glassOpacity / 255f;
            lampMaterial.sharedMaterial.color = lampGlassColor;

            sphereCollider.radius = collisionRadius;
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

            CircleInfo circleInfo2 = new CircleInfo
            {
                center = cirlceTransform.position,
                forward = cirlceTransform.forward,
                radius = collisionRadius,
                fillColor = Color.clear
            };

            if (Border)
            {
                circleInfo2.bordered = true;
                circleInfo2.borderColor = BorderColor;
                circleInfo2.borderWidth = BorderWidth;
            }

            Circle.Draw(circleInfo);
            Circle.Draw(circleInfo2);
        }

        void Update()
        {
            DrawCircle();
        }
    }
}

