using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunitionBoxLife : MonoBehaviour
{
    public GameObject ShipObject;
    public EBoxType BoxType;
    public MunitionBoxManager MunBoxManager;

    private List<EMovement> _currentMovement = new List<EMovement>();
    private float _moveSpeed = 0.07f;
    private BoxCollider _collider;


    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == ShipObject.name)
        {
            ChangeMunitionType();
            MunBoxManager.BoxUsed();
            Destroy(gameObject);
        }
    }

    private void Awake()
    {
        _currentMovement.Add(EMovement.Up);
        _currentMovement.Add(EMovement.Left);
        _collider = gameObject.GetComponent<BoxCollider>();


    }

    private void Start()
    {
        Vector3 screenPosition;
        do
        {
            screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 10));
        }
        while (Vector3.Distance(screenPosition, ShipObject.transform.position) < 2);

        transform.position = screenPosition;
    }

    private void Update()
    {
        transform.position = MoveWithinCamera(_currentMovement);
    }




    private Vector3 MoveWithinCamera(List<EMovement> movements)
    {
        Vector3 translation = Vector3.zero;
        Vector3 screenPoint;

        Bounds bounds = _collider.bounds;
        List<EMovement> changeList = new List<EMovement>();

        foreach (EMovement move in movements)
        {
            changeList.Add(move);
            switch (move)
            {
                case (EMovement.Right):
                    screenPoint = Camera.main.WorldToViewportPoint(bounds.max + new Vector3(_moveSpeed, 0f, 0f));
                    if (screenPoint.x < 1)
                    {
                        translation.x += _moveSpeed;
                    }
                    else
                    {
                        changeList.Remove(EMovement.Right);
                        changeList.Add(EMovement.Left);
                    }
                    break;

                case (EMovement.Left):
                    screenPoint = Camera.main.WorldToViewportPoint(bounds.min - new Vector3(_moveSpeed, 0f, 0f));
                    if (screenPoint.x > 0)
                    {
                        translation.x -= _moveSpeed;
                    }
                    else
                    {
                        changeList.Remove(EMovement.Left);
                        changeList.Add(EMovement.Right);
                    }
                    break;

                case (EMovement.Up):
                    screenPoint = Camera.main.WorldToViewportPoint(bounds.max + new Vector3(0f, _moveSpeed, 0f));
                    if (screenPoint.y < 1)
                    {
                        translation.y += _moveSpeed;
                    }
                    else
                    {
                        changeList.Remove(EMovement.Up);
                        changeList.Add(EMovement.Down);
                    }
                    break;

                case (EMovement.Down):
                    screenPoint = Camera.main.WorldToViewportPoint(bounds.min - new Vector3(0f, _moveSpeed, 0f));
                    if (screenPoint.y > 0)
                    {
                        translation.y -= _moveSpeed;
                    }
                    else
                    {
                        changeList.Remove(EMovement.Down);
                        changeList.Add(EMovement.Up);
                    }
                    break;
            }

        }

        _currentMovement = changeList;
        translation = translation.normalized * _moveSpeed;
        return transform.position + translation;
    }

    private void ChangeMunitionType()
    {
        switch(BoxType)
        {
            case EBoxType.yellowBox:
                MunitionManagement.Instance.SetYellowMun();
                break;
            case EBoxType.redBox:
                MunitionManagement.Instance.SetRedMun();
                break;
            case EBoxType.blueBox:
                MunitionManagement.Instance.SetBluewMun();
                break;
        }
    }
}
