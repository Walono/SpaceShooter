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

    private const int mainSideSphere = 10;
    private const int smallSideSphere = 5;
    private const int mainMidSphere = 20;
    private const int smallMidSphere = 15;

    private enum ELaserIndex
    {
        mainSideSphere = 0,
        smallSideSphere = 1,
        mainMidSphere = 2,
        smallMidSphere = 3
    }

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

    public override int GetMunPower(int subMunitionIndex)
    {
        if (subMunitionIndex == (int)ELaserIndex.mainSideSphere)
        {
            return mainSideSphere;
        }
        else if (subMunitionIndex == (int)ELaserIndex.smallSideSphere)
        {
            return smallSideSphere;
        }
        else if (subMunitionIndex == (int)ELaserIndex.mainMidSphere)
        {
            return mainMidSphere;
        }
        else if (subMunitionIndex == (int)ELaserIndex.smallMidSphere)
        {
            return smallMidSphere;
        }
        return 0;
    }
}