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
        [SerializeField, Range(0f, 255f)] private float glassOpacity = 78;
        [SerializeField, Range(0f, 10f)] private float intensity = 20;

        [Header("Sphere Radius")]
        [SerializeField] private float collisionRadius = 1.5f;
        [SerializeField] private SphereCollider sphereCollider;

        public Color LampColor => lampColor;
        public float Radius => radius;

        public TypeOfColor TypeOfColor;
        public Transform CirlceTransform => circle.transform;

          [Header("Light Radius")]
        /*
        [SerializeField] private Transform cirlceTransform;
        [SerializeField] public Color FillColor;
        [SerializeField] private bool Border;
        public Color BorderColor;
        [Range(0f, 0.8f)]
        public float BorderWidth = 0.2f;*/

        [SerializeField] private GameObject circle;
        [SerializeField] private MeshRenderer circleMaterial;
        private Color circleColor;
        [SerializeField, Range(0f, 1f)] private float circleOpacity;

        void Start()
        {
            Refresh();
        }

        public void SetCirclePosition(Vector3 position)
        {
            circle.transform.position = position;
            //Border = false;
        }

        public void SetDefaultCirclePosition()
        {
            circle.transform.position = gameObject.transform.position;
            //Border = true;
        }


        public void Refresh()
        {
            lampColor.a = 255f;
            pointLight.color = lampColor;
            pointLight.range = radius;
            pointLight.intensity = intensity;
            circleMaterial.sharedMaterial.color = lampGlassColor;

            circleColor = lampColor;
            circleColor.a = circleOpacity;
            circleMaterial.sharedMaterial.color = circleColor;
            CirlceTransform.localScale = new Vector3(radius * 2.1235f, radius * 2.1235f, radius * 2.1235f);

            lampGlassColor = lampColor;
            lampGlassColor.a = glassOpacity / 255f;
            lampMaterial.sharedMaterial.color = lampGlassColor;

            sphereCollider.radius = collisionRadius;
        }

        public void DrawCircle()
        {
            /*
            CircleInfo circleInfo = new CircleInfo
            {
                center = CirlceTransform.position,
                forward = CirlceTransform.forward,
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
            
            Circle.Draw(circleInfo2);
            Circle.Draw(circleInfo);*/
        }

        void Update()
        {
            DrawCircle();
        }
    }
}

