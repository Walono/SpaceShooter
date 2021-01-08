using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMunitions : Munitions
{
    private void Awake()
    {
        InitialPose = transform.position;
    }

    private void Update()
    {
        transform.position += new Vector3(0f, MunSpeed, 0f);

        if (transform.position.y - InitialPose.y >= MaxRange)
        {
            Destroy(gameObject);
        }
    }
}//copied YellowMunitions and changed heritage to Munitions