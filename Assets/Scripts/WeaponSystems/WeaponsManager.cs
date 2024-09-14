using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    public enum Weapons
    {
        Pistol,
        SnowBall,
        Fist
    }

    public List<Weapons> throwables = new List<Weapons>();

    public Transform weaponHolder;
    public KeyCode fireKey = KeyCode.Mouse0;
    private ThrowingProjectilesScript projScript;



    public Weapons equippedWeapon;


    private void Awake()
    {
        projScript = gameObject.GetComponent<ThrowingProjectilesScript>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(fireKey))
        {
            // Fire whatever weapon is currently equipped.
            Fire();
        }
    }

    private void Start()
    {
        
    }


    public void equipWeapon(Weapons weaponType)
    {
        equippedWeapon = weaponType;
        if (equippedWeapon == Weapons.Pistol)
        {
            weaponHolder.Find("Pistol").gameObject.SetActive(true);
        }


        else if (equippedWeapon == Weapons.Fist)
        {
            weaponHolder.Find("Fist").gameObject.SetActive(true);
        }
        

        else if (equippedWeapon == Weapons.SnowBall)
        {
            weaponHolder.Find("Snowball").gameObject.SetActive(true);
        }


        else
        {
            Debug.LogWarning("No weapon found in weaponTransform");
        }
    }

    public void unequipWeapon(Weapons weaponType)
    {
        equippedWeapon = Weapons.Fist;

        if (equippedWeapon == Weapons.Pistol)
        {
            weaponHolder.Find("Pistol").gameObject.SetActive(false);
        }


        else if (equippedWeapon == Weapons.Fist)
        {
            weaponHolder.Find("Fist").gameObject.SetActive(false);
        }


        else if (equippedWeapon == Weapons.SnowBall)
        {
            weaponHolder.Find("Snowball").gameObject.SetActive(false);
        }


        else
        {
            Debug.LogWarning("No weapon found in weaponTransform");
        }
    }

    void Fire()
    {
        if (throwables.Contains(equippedWeapon)) {
            // Fire throwable weapon
            projScript.objectToThrow = projScript.objectsToThrow[0];
            projScript.Throw();
        }
        else
        {
            if (equippedWeapon == Weapons.Fist)
            {
                // Fist logic
            }
            else
            {
                if (equippedWeapon == Weapons.Pistol)
                {
                    // Shoot Pistol

                }
            }
        }
    }

}
