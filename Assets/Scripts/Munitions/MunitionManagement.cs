using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionManagement : MonoBehaviour
{
    [SerializeField]
    public GameObject YellowMunPrefab;
    public GameObject RedMunPrefab;  //add red prefab
    

    private GameObject _currentMunType;
    private float _shootCooldown;

    private bool _canShoot = true;
    private float _timer = 0;

    private void Start()
    {
        SetRedMun();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_canShoot)
        {
            _timer += Time.deltaTime;
            if (_timer >= _shootCooldown)
            {
                _canShoot = true;
            }
        }
    }

    public void Fire()
    {
        if (_canShoot)
        {
            _canShoot = false;
            Instantiate(_currentMunType, ShipManagement.Instance.transform.position, ShipManagement.Instance.transform.rotation);
            _timer = 0f;
        }
    }

    public void SetYellowMun()
    {
        _currentMunType = YellowMunPrefab;
        _shootCooldown = 0.2f;
    }

    public void SetRedMun()
    {
        _currentMunType = RedMunPrefab;
        _shootCooldown = 0.2f;
        // Set parameters for red munitions.
    }
}