#if UNITY_EDITOR
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
        lamp.Refresh();
    }

    private void OnSceneGUI()
    {
        Lamp lamp = (Lamp)target;

        /*Draw the whole circunference*/
        Handles.color = Color.white;
        Handles.DrawWireArc(lamp.transform.position, Vector3.up, Vector3.forward, 360, lamp.Radius);
        Handles.DrawWireArc(lamp.transform.position, Vector3.up, Vector3.forward, 360, lamp.Radius);

        /*Vector of the direction of lines in the circunference*/
        Vector3 viewAngle01 = DirectionFromAngle(lamp.transform.eulerAngles.y, -90);
        Vector3 viewAngle02 = DirectionFromAngle(lamp.transform.eulerAngles.y, 90);
        Vector3 viewAngle03 = DirectionFromAngle(lamp.transform.eulerAngles.y, 0);
        Vector3 viewAngle04 = DirectionFromAngle(lamp.transform.eulerAngles.y, 180);

        /*Draw lines in the circunference*/
        Handles.DrawLine(lamp.transform.position, lamp.transform.position + viewAngle01 * lamp.Radius);
        Handles.DrawLine(lamp.transform.position, lamp.transform.position + viewAngle02 * lamp.Radius);
        Handles.DrawLine(lamp.transform.position, lamp.transform.position + viewAngle03 * lamp.Radius);
        Handles.DrawLine(lamp.transform.position, lamp.transform.position + viewAngle04 * lamp.Radius);

        lamp.DrawCircle();
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
}
#endif
