﻿using UnityEngine;

public class YellowMunitions : Munitions
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
}