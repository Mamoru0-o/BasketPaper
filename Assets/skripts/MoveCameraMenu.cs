using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MoveCameraMenu : MonoBehaviour
{
    [SerializeField] protected GameObject RotatePoint;
    static protected bool Move;

    private void Start()
    {
        Move = true;
    }
    void Update()
    {
        if (Move) 
        {
            RotatePoint.transform.Rotate(0, 0, 10 * Time.deltaTime);
        }
    }
}
