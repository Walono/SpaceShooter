using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

        Vector3 newPose = transform.position;

        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            newPose += new Vector3(0f, 0.1f, 0f);
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            newPose -= new Vector3(0f, 0.1f, 0f);
        }
        // TODO: Add left and right movements.

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(newPose);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        if (onScreen)
        {
            transform.position = newPose;
        }
    }
}
