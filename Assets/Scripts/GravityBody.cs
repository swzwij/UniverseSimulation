using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float mass;
    public float radius;
    public Vector3 initialVelocity;
    Vector3 currentVelocity;

    private void Awake()
    {
        currentVelocity = initialVelocity;
    }

    public void UpdateVelocity(GravityBody[] allBodies, float timeStep)
    {
        foreach(var otherBody in allBodies)
        {
            if(otherBody != this)
            {
                float sqrDst = (otherBody.rigidbody.position - rigidbody.position).sqrMagnitude;
                Vector3 forceDir = (otherBody.rigidbody.position - rigidbody.position).normalized;
                Vector3 force = forceDir * 1 * mass * otherBody.mass / sqrDst;
                Vector3 acceleration = force / mass;
                currentVelocity += acceleration * timeStep;
            }
        }
    }

    public void UpdatePosition(float timeStep)
    {
        rigidbody.position += currentVelocity * timeStep;
    }
}
