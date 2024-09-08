using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Projectile", order = 1)]
public class Projectile : ScriptableObject
{
    public float upwardForce;
    public float forwardForce;

    public GameObject objectToThrow;
}