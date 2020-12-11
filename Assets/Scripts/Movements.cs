using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            transform.position = transform.position + new Vector3(0f,0.05f,0f);
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            transform.position = transform.position - new Vector3(0f, 0.05f, 0f);
        }
        // TODO: Add left and right movements.
    }
}
