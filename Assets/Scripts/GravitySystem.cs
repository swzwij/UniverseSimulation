using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySystem : MonoBehaviour
{
    GravityBody[] bodies;

    public float timeStep = 1;

    private void Awake()
    {
        bodies = FindObjectsOfType<GravityBody>();
        //Time.fixedDeltaTime = timeStep;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdateVelocity(bodies,timeStep);
        }

        for (int i = 0; i < bodies.Length; i++)
        {
            bodies[i].UpdatePosition(timeStep);
        }
    }
}
