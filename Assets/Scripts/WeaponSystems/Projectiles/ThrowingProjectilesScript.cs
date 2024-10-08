using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ThrowingProjectilesScript : MonoBehaviour
{

    public int equippedProjectile = 0;
    [Header("Throwables")]
    public List<Projectile> scripts = new List<Projectile>();


    #region
    [Header("References")]
    public Transform cam;
    public Transform attackPoint;
    public List<GameObject> objectsToThrow = new List<GameObject>();
    public GameObject objectToThrow;

    [Header("Settings")]
    public int totalThrows;
    public float throwCooldown;

    [Header("Throwing")]
    public KeyCode throwKey = KeyCode.Mouse0;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;

    private void Start()
    {
        readyToThrow = true;
    }

    private void Update()
    {
        // Code to throw when left click is pressed (or whatever key is the throwKey)
        /*
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0)
        {
            Throw();
        }
        */
        objectToThrow = scripts[equippedProjectile].objectToThrow;
    }

    public void Throw()
    {
        if (!readyToThrow)
        {
            return;
        }

        throwForce = scripts[equippedProjectile].forwardForce;
        throwUpwardForce = scripts[equippedProjectile].forwardForce;

        readyToThrow = false;

        // instantiate object to throw
        GameObject projectile = Instantiate(objectToThrow, attackPoint.position, cam.rotation);

        // get rigidbody component
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        // calculate direction
        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }

        // add force
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;

        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        // implement throwCooldown
        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
    #endregion
}