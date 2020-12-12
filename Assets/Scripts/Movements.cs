using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    private enum EMovement
    {
        Up,
        Down,
        Left,
        Right
    }

    private float _displacement = 0.1f;

    // Update is called once per frame
    private void Update()
    {
        List<EMovement> movements = new List<EMovement>();

        if (Input.GetKey("up") || Input.GetKey("w"))
        {
            movements.Add(EMovement.Up);
        }
        if (Input.GetKey("down") || Input.GetKey("s"))
        {
            movements.Add(EMovement.Down);
        }
        if (Input.GetKey("left") || Input.GetKey("a"))
        {
            movements.Add(EMovement.Left);
        }
        if (Input.GetKey("right") || Input.GetKey("d"))
        {
            movements.Add(EMovement.Right);
        }

        transform.position = NewPoseWithinCamera(movements);
    }

    private Vector3 NewPoseWithinCamera(List<EMovement> movements)
    {
        Vector3 translation = Vector3.zero;
        Vector3 screenPoint;

        foreach (EMovement move in movements)
        {
            switch (move)
            {
                case (EMovement.Right):
                    screenPoint = Camera.main.WorldToViewportPoint(transform.position + new Vector3(_displacement, 0f, 0f));
                    if (screenPoint.x < 1)
                    {
                        translation.x += _displacement;
                    }
                    break;

                case (EMovement.Left):
                    screenPoint = Camera.main.WorldToViewportPoint(transform.position - new Vector3(_displacement, 0f, 0f));
                    if (screenPoint.x > 0)
                    {
                        translation.x -= _displacement;
                    }
                    break;

                case (EMovement.Up):
                    screenPoint = Camera.main.WorldToViewportPoint(transform.position + new Vector3(0f, _displacement, 0f));
                    if (screenPoint.y < 1)
                    {
                        translation.y += _displacement;
                    }
                    break;

                case (EMovement.Down):
                    screenPoint = Camera.main.WorldToViewportPoint(transform.position - new Vector3(0f, _displacement, 0f));
                    if (screenPoint.y > 0)
                    {
                        translation.y -= _displacement;
                    }
                    break;
            }
        }
        translation = translation.normalized * _displacement;
        return transform.position + translation;
    }
}