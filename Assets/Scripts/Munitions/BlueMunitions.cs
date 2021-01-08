using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMunitions : Munitions
{
    [SerializeField]
    private GameObject _middleOrb;

    [SerializeField]
    private GameObject _leftOrb;

    [SerializeField]
    private GameObject _rightOrb;

    private float _angle = 0;
    private float _sideMove = .04f;

    private void Awake()
    {
        InitialPose = transform.position;
    }

    private void Update()
    {
        _angle += 3f;
        transform.position += new Vector3(0f, MunSpeed, 0f);

        if (transform.position.y - InitialPose.y >= MaxRange)
        {
            Destroy(gameObject);
        }

        Vector3 leftePose = new Vector3(-_sideMove, 0f, 0f);
        Vector3 rightPose = new Vector3(_sideMove, 0f, 0f);

        Vector3 rotateOrb = new Vector3(0f, 0f, _angle);

        _middleOrb.transform.localRotation = Quaternion.Euler(rotateOrb);
        _leftOrb.transform.localPosition += leftePose;
        _leftOrb.transform.localRotation = Quaternion.Euler(rotateOrb);
        _rightOrb.transform.localPosition += rightPose;
        _rightOrb.transform.localRotation = Quaternion.Euler(rotateOrb);
    }
}