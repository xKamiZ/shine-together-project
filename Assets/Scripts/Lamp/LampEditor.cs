//#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using ShineTogether;

    [CustomEditor(typeof(Lamp))]
    public class LampEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            Lamp lamp = (Lamp)target;
            lamp.ChangeValues();
            Debug.Log("on inspector gui");
        }

        private void OnSceneGUI()
        {
            Lamp lamp = (Lamp)target;

            /*Draw angle*/
            Handles.color = lamp.LampColor;
            Handles.DrawWireArc(lamp.transform.position, Vector3.up, Vector3.forward, 360, lamp.Radius);
            Handles.DrawWireArc(lamp.transform.position, Vector3.up, Vector3.forward, 360, lamp.LightRadius);

            /*Vision angle*/
            Vector3 viewAngle01 = DirectionFromAngle(lamp.transform.eulerAngles.y, -90);
            Vector3 viewAngle02 = DirectionFromAngle(lamp.transform.eulerAngles.y, 90);
            Vector3 viewAngle03 = DirectionFromAngle(lamp.transform.eulerAngles.y, 0);
            Vector3 viewAngle04 = DirectionFromAngle(lamp.transform.eulerAngles.y, 180);

            /*Draw vision angle*/
            Handles.DrawLine(lamp.transform.position, lamp.transform.position + viewAngle01 * lamp.LightRadius);
            Handles.DrawLine(lamp.transform.position, lamp.transform.position + viewAngle02 * lamp.LightRadius);
            Handles.DrawLine(lamp.transform.position, lamp.transform.position + viewAngle03 * lamp.LightRadius);
            Handles.DrawLine(lamp.transform.position, lamp.transform.position + viewAngle04 * lamp.LightRadius);
        }

        /// <summary>
        /// Return the vector direction
        /// </summary>
        /// <param name="eulerY">Rotation angle</param>
        /// <param name="angleInDegrees">Angle</param>
        /// <returns></returns>
        private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
        {
            angleInDegrees += eulerY;
            return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
        }
//#endif
    }
