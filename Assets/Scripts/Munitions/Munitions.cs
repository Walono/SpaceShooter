using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Munitions : MonoBehaviour
{
    [SerializeField]
    public float MunSpeed = 0.7f;

    [SerializeField]
    public float MaxRange = 12f;

    public Vector3 InitialPose;

    public abstract int GetMunPower(int subMunitionIndex);
}