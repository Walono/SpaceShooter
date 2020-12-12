using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMunitions : MonoBehaviour
{
    [SerializeField]
    private float _munSpeed = 0.7f;

    [SerializeField]
    private float _maxRange = 3f;

    private Vector3 _initialPose;

    private void Awake()
    {
        _initialPose = transform.position;
    }

    private void Update()
    {
        transform.position += new Vector3(0f, _munSpeed, 0f);

        if (transform.position.y - _initialPose.y >= _maxRange)
        {
            Destroy(gameObject);
        }
    }
}