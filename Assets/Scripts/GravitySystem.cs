using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySystem : MonoBehaviour
{
    GravityBody[] bodies;
    private Universe _universe;
    
    private void Awake()
    {
        bodies = FindObjectsOfType<GravityBody>();
        _universe = GetComponentInParent<Universe>();
        //Time.fixedDeltaTime = timeStep;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdateVelocity(bodies, _universe.timeStep, _universe.physicsGravity);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(_universe.timeStep);
        }
    }
}
