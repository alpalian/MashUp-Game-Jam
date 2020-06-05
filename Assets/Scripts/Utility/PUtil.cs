using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PUtil
{
    public static Vector3 Orthogonalise(this Vector3 vector, Vector3 normal) //we don't assume normal is normalised
    {
        return vector - normal * Vector3.Dot(normal, vector) / normal.sqrMagnitude;
    }
}
