using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButton ("Fire1")) {
            transform.Rotate(0, .5f, 0);
        }
        if (Input.GetButton ("Fire2")) {
            transform.Rotate(0, -.5f, 0);
        }
    }
}
