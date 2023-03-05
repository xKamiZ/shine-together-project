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
        private TypeOfColor typeOfColor; 
        private Lamp redLamp;
        private Lamp blueLamp;

        public void DefaultValues(TypeOfColor typeOfColor, Lamp redLamp, Lamp blueLamp)
        {
            this.typeOfColor = typeOfColor;
            this.redLamp = redLamp;
            this.blueLamp = blueLamp;
        }

        private void Update()
        {
            float distance1 = Mathf.Pow(redLamp.transform.position.x - transform.position.x, 2) +
                       Mathf.Pow(redLamp.transform.position.z - transform.position.z, 2);
            float distance2 = Mathf.Pow(blueLamp.transform.position.x - transform.position.x, 2) +
                       Mathf.Pow(blueLamp.transform.position.z - transform.position.z, 2);
            float distance3 = Mathf.Pow(blueLamp.transform.position.x - redLamp.transform.position.x, 2) +
                      Mathf.Pow(blueLamp.transform.position.z - redLamp.transform.position.z, 2);

            float raidus1 = Mathf.Pow(redLamp.Radius, 2);
            float raidus2 = Mathf.Pow(blueLamp.Radius, 2);
            float raidus3 = Mathf.Pow((redLamp.Radius + blueLamp.Radius),2);

            Debug.Log($"distance1: {distance1}, distance2: {distance2}, distance3: {distance3}.  " +
                $"raidus1: {raidus1}, raidus2: {raidus2}, raidus3: {raidus3}");
            if (typeOfColor == TypeOfColor.Purple) 
            {
                active = distance1 <= raidus1 && distance2 <= raidus2 && distance3 <= raidus3;
            }
            else
            {
                active = !(distance1 <= raidus1 && distance2 <= raidus2 && distance3 <= raidus3);
                if(active)
                    active = typeOfColor == TypeOfColor.Red ? distance1 <= raidus1 : distance2 <= raidus2;
            }
        }
    }
}
