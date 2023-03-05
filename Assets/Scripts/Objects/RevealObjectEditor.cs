#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using ShineTogether;
using Shapes;

[CustomEditor(typeof(RevealObject))]
public class RevealObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RevealObject revealObject = (RevealObject)target;
        revealObject.Refresh();
    }

    private void OnSceneGUI()
    {   
        RevealObject revealObject = (RevealObject)target;

        Handles.color = Color.white;
        foreach(RevealPoint revealPoint in revealObject.revealPoints)
        {
            Handles.DrawWireArc(revealPoint.transform.position, Vector3.up, Vector3.forward, 360, revealObject.Radius);
        }
    }
}
#endif
