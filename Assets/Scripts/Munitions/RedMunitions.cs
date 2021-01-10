using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMunitions : Munitions
{
    private const int _sideLaserPower = 10;
    private const int _midLaserPower = 20;

    private enum ELaserIndex
    {
        sideLaser = 0,
        midLaser = 1,
    }

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

    public override int GetMunPower(int subMunitionIndex)
    {
        if (subMunitionIndex == (int)ELaserIndex.sideLaser)
        {
            return _sideLaserPower;
        }
        else if (subMunitionIndex == (int)ELaserIndex.midLaser)
        {
            return _midLaserPower;
        }
        return 0;
    }
}//copied YellowMunitions and changed heritage to Munitions