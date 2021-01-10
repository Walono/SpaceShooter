using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubMunitionIndex : MonoBehaviour
{
    [SerializeField]
    private int _subMunitionIndex = 0;

    public int GetSubMunitionIndex()
    {
        return _subMunitionIndex;
    }
}