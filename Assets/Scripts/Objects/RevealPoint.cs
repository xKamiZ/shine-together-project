using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.Controls.AxisControl;

namespace ShineTogether
{
    public enum TypeOfColor { Red, Blue, Purple }
    public class RevealPoint : MonoBehaviour
    {
        public bool active;
        [HideInInspector] public TypeOfColor typeOfColor; 
        [HideInInspector] public float radius;
        [HideInInspector] public Lamp redLamp;
        [HideInInspector] public Lamp blueLamp;

        private void OnTriggerStay(Collider other)
        {
            if (other.TryGetComponent(out Lamp lamp))
            {
                if(lamp.TypeOfColor == typeOfColor)
                    active = true;
                else
                {
                    
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            active = false;
        }

        private void FixedUpdate()
        {
            if (typeOfColor != TypeOfColor.Purple) return;
            float distance1 = Mathf.Pow(redLamp.transform.position.x - transform.position.x, 2) +
                       Mathf.Pow(redLamp.transform.position.y - transform.position.y, 2);
            float distance2 = Mathf.Pow(blueLamp.transform.position.x - transform.position.x, 2) +
                      Mathf.Pow(blueLamp.transform.position.y - transform.position.y, 2);
            float raidus = Mathf.Pow((redLamp.Radius + blueLamp.Radius) / 2, 2);
            Debug.Log(distance2 + " " + distance1 + " " + raidus);
            // (R0 - R1) ^ 2 <= (x0 - x1) ^ 2 + (y0 - y1) ^ 2
            if (distance2 <= raidus && distance1 <= raidus)
            {
                active = distance2 <= raidus && distance1 <= raidus;
                Debug.Log("Purple");
            }
        }
    }
}
